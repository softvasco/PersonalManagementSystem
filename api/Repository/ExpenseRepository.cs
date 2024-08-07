﻿using api.Data;
using Shared.Dtos.Expenses;
using Shared.Enum;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDBContext _context;

        public ExpenseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseDto>> GetAsync()
        {
            var expenses = await _context.Expenses
              .Where(x => x.IsActive)
              .ToListAsync();

            if (expenses == null || !expenses.Any())
            {
                throw new NotFoundException("No expenses found for the specified user");
            }

            var subCategoryIds = expenses.Select(x => x.SubCategoryId).Distinct().ToList();
            var subCategoryNames = await _context.SubCategories
                .Where(x => subCategoryIds.Contains(x.Id))
                .Select(x => new { Id = x.Id, Name = x.Description })
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            // Add new item to the dictionary
            if (!subCategoryNames.ContainsKey(0))
            {
                subCategoryNames[0] = "Other";
            }

            return expenses.Select(c =>
            {
                var expenseDto = c.ToExpenseDtoFromExpense();
                expenseDto.SubCategoryName = subCategoryNames[c.SubCategoryId];
                return expenseDto;
            }).ToList();
        }

        public async Task<Expense> CreateAsync(Expense expense)
        {
            var expenseExists = await _context
                .Expenses
                .AsNoTracking()
                .AnyAsync(x => x.Code == expense.Code
                    && x.UserId == expense.UserId
                    && x.IsActive);

            if (expenseExists)
            {
                throw new Exception("Expense already exists!");
            }

            expense.StartDate = DateTime.Now.Date;
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            DateTime indexData = Utils.CalculateNextPaymentDate(expense.StartDate, expense.PayDay);
            SubCategory? subCategory = await _context.SubCategories.FindAsync(expense.SubCategoryId);

            while (indexData < expense.EndDate)
            {
                if (expense.Months.Contains(indexData.Month) && expense.Amount > 0)
                {
                    await _context.Transactions.AddAsync(new Transaction
                    {
                        OperationDate = indexData,
                        Description = expense.Description,
                        State = (int)TransactionState.Pending,
                        ExpenseId = expense.Id,
                        SourceAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.SourceAccountOrCardCode) ? expense.SourceAccountOrCardCode : string.Empty,
                        DestinationAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.DestinationAccountOrCardCode) ? expense.DestinationAccountOrCardCode : string.Empty,
                        Amount = expense.Amount,
                        UserId = expense.UserId,
                        SubCategoryId = (subCategory != null) ? subCategory.Id : null,
                        FileName = string.Empty,
                        Attachment = null
                    });
                }

                indexData = indexData.AddMonths(1);
            }

            await _context.SaveChangesAsync();

            return expense;
        }


        public async Task<Expense> UpdateAsync(int id, Expense expense)
        {
            var existingExpense = await _context
              .Expenses
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingExpense == null)
            {
                throw new NotFoundException("Expense not found");
            }

            existingExpense.UpdatedDate = DateTime.UtcNow;
            existingExpense.Description = expense.Description;
            existingExpense.Code = expense.Code;
            existingExpense.Months = expense.Months;
            existingExpense.EndDate = expense.EndDate;
            existingExpense.StartDate = DateTime.Now;
            existingExpense.Amount = expense.Amount;
            existingExpense.DestinationAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.DestinationAccountOrCardCode) ? expense.DestinationAccountOrCardCode : string.Empty;
            existingExpense.UserId = expense.UserId;
            existingExpense.PayDay = expense.PayDay;
            existingExpense.SourceAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.SourceAccountOrCardCode) ? expense.SourceAccountOrCardCode : string.Empty;
            existingExpense.SubCategoryId = expense.SubCategoryId;

            SubCategory? subCategory = await _context.SubCategories.FindAsync(expense.SubCategoryId);

            try
            {
                _context.Entry(existingExpense).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _context.Transactions.RemoveRange(_context
                    .Transactions
                    .Where(x => x.ExpenseId == existingExpense.Id 
                        && x.State == (int)TransactionState.Pending
                        && (x.Attachment == null || x.Attachment.Length==0)));
                await _context.SaveChangesAsync();

                DateTime indexData = Utils.CalculateNextPaymentDate(existingExpense.StartDate, expense.PayDay);

                while (indexData < expense.EndDate)
                {
                    if (expense.Months.Contains(indexData.Month)
                        && expense.Amount > 0
                        && !_context.Transactions.Any(x => x.ExpenseId == existingExpense.Id && x.OperationDate == indexData))
                    {
                        await _context.Transactions.AddAsync(new Transaction
                        {
                            OperationDate = indexData,
                            Description = expense.Description,
                            State = (int)TransactionState.Pending,
                            UserId = expense.UserId,
                            ExpenseId = existingExpense.Id,
                            SourceAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.SourceAccountOrCardCode) ? expense.SourceAccountOrCardCode : string.Empty,
                            DestinationAccountOrCardCode = !string.IsNullOrWhiteSpace(expense.DestinationAccountOrCardCode) ? expense.DestinationAccountOrCardCode : string.Empty,
                            Amount = expense.Amount,
                            Attachment = null,
                            SubCategoryId = subCategory?.Id,
                            FileName = string.Empty
                        });
                    }

                    indexData = indexData.AddMonths(1);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingExpense;
        }

        public async Task<Expense> DeleteAsync(int id)
        {
            var existingExpense = await _context
              .Expenses
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingExpense == null)
            {
                throw new NotFoundException("Expense not found");
            }

            existingExpense.UpdatedDate = DateTime.Now;
            existingExpense.IsActive = false;

            try
            {
                _context.Entry(existingExpense).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _context.Transactions.RemoveRange(_context.Transactions.Where(x => x.ExpenseId == id && x.State == (int)TransactionState.Pending));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingExpense;
        }


    }
}