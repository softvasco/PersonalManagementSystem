using api.Data;
using Shared.Dtos.Categories;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class WeightRepository : IWeightRepository
    {
        private readonly ApplicationDBContext _context;

        public WeightRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the last 7 registered weights for the specified user and active status.
        /// </summary>
        /// <returns>A list of `WeigthDto` representing the last 7 registered weights.</returns>
        public async Task<List<WeigthDto>> GetAsync()
        {
            // Filter the Weigth entities based on the user ID and active status
            var weigths = await _context
                .Weigth
                .Where(x => x.UserId == 1 && x.IsActive)
                .ToListAsync();

            // Select only the necessary properties and convert to WeigthDto
            var weigthDtos = weigths.Select(z => z.ToWeigthDtoFromWeigth()).ToList();

            // Order the selected entities by RegistrationDate in descending order
            weigthDtos = weigthDtos.OrderByDescending(x => x.RegistrationDate).ToList();

            // Limit the result set to the last 7 entities
            weigthDtos = weigthDtos.Take(7).ToList();

            return weigthDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weigth"></param>
        /// <returns></returns>
        public async Task<Weigth> CreateAsync(Weigth weigth)
        {
            await _context.Weigth.AddAsync(weigth);
            await _context.SaveChangesAsync();

            return weigth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Weigth> DeleteAsync(int id)
        {
            Weigth? Weigth = await _context.Weigth.FindAsync(id);

            if (Weigth is null)
            {
                throw new NotFoundException("Weigth not found");
            }
            else
            {
                Weigth.UpdatedDate = DateTime.Now;
                Weigth.IsActive = false;

                try
                {
                    _context.Entry(Weigth).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return Weigth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weigth"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Weigth> UpdateAsync(int id, Weigth weigth)
        {
            var existingWeigth = await _context
               .Weigth
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingWeigth == null)
            {
                throw new NotFoundException("Weigth not found");
            }

            existingWeigth.UpdatedDate = DateTime.UtcNow;
            existingWeigth.Description = weigth.Description;
            existingWeigth.RegistrationDate = weigth.RegistrationDate;
            existingWeigth.Kg = weigth.Kg;

            try
            {
                _context.Entry(existingWeigth).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingWeigth;
        }
    }
}