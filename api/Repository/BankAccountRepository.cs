using api.Data;
using api.Dtos.BankAccounts;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public BankAccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> CreateAsync(BankAccount bankAccount)
        {
            var userExists = await _context
                .Users
                .AsNoTracking()
                .AnyAsync(x => x.Id == bankAccount.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var bankAccountExists = await _context
                .BankAccounts
                .AsNoTracking()
                .AnyAsync(x => x.Code == bankAccount.Code
                    && x.UserId == bankAccount.UserId
                    && x.IsActive);

            if (bankAccountExists)
            {
                throw new Exception("Bank account already exists!");
            }

            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();

            return bankAccount;
        }

        public async Task<BankAccountDto> GetByCodeAsync(string code)
        {
            var existingBankAccount = await _context
                .BankAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingBankAccount == null)
            {
                throw new NotFoundException("Bank account not found");
            }

            return existingBankAccount.ToBankAccountDtoFromBankAccount();
        }

        public async Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount)
        {
            var existingBankAccount = await _context
                .BankAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingBankAccount == null)
            {
                throw new NotFoundException("Bank account not found");
            }

            existingBankAccount.UpdatedDate = DateTime.UtcNow;
            existingBankAccount.OpenDate = bankAccount.OpenDate;
            existingBankAccount.CloseDate = bankAccount.CloseDate;
            existingBankAccount.Description = bankAccount.Description;
            if (existingBankAccount.CloseDate is not null)
                existingBankAccount.IsActive = false;
            existingBankAccount.Balance = bankAccount.Balance;
            existingBankAccount.IBAN = bankAccount.IBAN;
            existingBankAccount.NIB = bankAccount.NIB;
            existingBankAccount.Number = bankAccount.Number;
            existingBankAccount.Code = bankAccount.Code;
            existingBankAccount.Swift = bankAccount.Swift;

            //Only update for a newer file. 
            if (bankAccount.Attachment != null)
                existingBankAccount.Attachment = bankAccount.Attachment;

            try
            {
                _context.Entry(existingBankAccount).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingBankAccount;
        }

        public async Task<BankAccount> DeleteAsync(int id)
        {
            var bankAccount = await _context
                .BankAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (bankAccount is null)
            {
                return null!;
            }

            bankAccount.IsActive = false;
            _context.Entry(bankAccount).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return bankAccount;
        }

        public async Task<BankAccount> UpdateBalanceAsync(int id, decimal balance)
        {
            try
            {
                BankAccount? bankAccount = await _context.BankAccounts.FindAsync(id);

                if (bankAccount is null)
                    throw new Exception("Bank account does not exists!");


                bankAccount.Balance = balance;
                bankAccount.UpdatedDate = DateTime.UtcNow;
                _context.Entry(bankAccount).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return bankAccount;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

    }
}