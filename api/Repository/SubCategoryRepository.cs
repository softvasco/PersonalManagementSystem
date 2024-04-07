using api.Data;
using Shared.Dtos.SubCategories;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public SubCategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoryDto>> GetAsync()
        {
            var subCategories = await _context
                .SubCategories
               .Where(x => x.IsActive)
               .Include(x => x.Category)
               .OrderBy(x => x.Category.Description)
               .ToListAsync();

            if (subCategories == null || !subCategories.Any())
            {
                throw new NotFoundException("No sub categories categories found for the specified user");
            }

            return subCategories.Select(c => c.ToSubCategoryDtoFromSubCategory()).ToList();
        }

        public async Task<SubCategory> CreateAsync(SubCategory subCategory)
        {
            //if (!_context
            //    .Users
            //    .AsNoTracking()
            //    .Any(x => x.Id == category.UserId && x.IsActive))
            //    throw new Exception("User does not exists!");

            if (_context
                .SubCategories
                .Any(x => x.Code == subCategory.Code /*&& x.UserId == category.UserId*/ && x.IsActive))
                throw new Exception("Category already exists!");

            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> UpdateAsync(int id, SubCategory subCategory)
        {
            var existingSubCategory = await _context
               .SubCategories
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingSubCategory == null)
            {
                throw new NotFoundException("Sub Category not found");
            }

            existingSubCategory.UpdatedDate = DateTime.UtcNow;
            existingSubCategory.Description = subCategory.Description;
            existingSubCategory.Code = subCategory.Code;
            existingSubCategory.MonthlyPlafond = subCategory.MonthlyPlafond;
            existingSubCategory.AnnualPlafon = subCategory.AnnualPlafon;

            try
            {
                _context.Entry(existingSubCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingSubCategory;
        }

        public async Task<SubCategory> DeleteAsync(int id)
        {
            var existingSubCategory = await _context
              .SubCategories
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingSubCategory == null)
            {
                throw new NotFoundException("Sub Category not found");
            }

            existingSubCategory.UpdatedDate = DateTime.Now;
            existingSubCategory.IsActive = false;

            try
            {
                _context.Entry(existingSubCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingSubCategory;
        }

    }
}