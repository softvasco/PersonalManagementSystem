using api.Data;
using api.Interfaces;
using api.Models;
using Shared.Dtos.OSRS;

namespace api.Repository
{
    public class OSRSRepository : IOSRSRepository
    {
        private readonly ApplicationDBContext _context;

        public OSRSRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AddOSRSAccountsDto addOSRSAccountsDto)
        {
            string[] _accounts = addOSRSAccountsDto.AccountsInfo.Split('\n');

            List<OSRSAccount> lstOfOSRSAccount = [];

            foreach (string account in _accounts)
            {
                try
                {
                    string[] _accountParts = account.Split(":");
                    string _email = _accountParts[0];
                    string _password = _accountParts[1];
                    string _bankpin = _accountParts[2];

                    if (!_context.OSRSAccounts.Any(p => p.Email == _email))
                    {
                        lstOfOSRSAccount.Add(new OSRSAccount()
                        {
                            CreatedDate= DateTime.Now,
                            IsActive= false,
                            IsBanned=false,
                            UpdatedDate = DateTime.Now,
                            Email= _email,
                            Password= _password,
                            BankPin= _bankpin

                        });
                    }
                }
                catch { }
            }

            await _context.OSRSAccounts.AddRangeAsync(lstOfOSRSAccount);
            await _context.SaveChangesAsync();
        }

        //public async Task<List<ProxyDto>> GetProxiesAsync()
        //{
        //    await _context.OSRSProxies.ToListAsync();

        //    return null!;
        //}

        ///// <summary>
        ///// Retrieves the last 7 registered weights for the specified user and active status.
        ///// </summary>
        ///// <returns>A list of `WeigthDto` representing the last 7 registered weights.</returns>
        //public async Task<List<WeigthDto>> GetAsync()
        //{
        //    // Filter the Weigths entities based on the user ID and active status
        //    var weigths = await _context
        //        .Weigths
        //        .Where(x => x.UserId == 1 && x.IsActive)
        //        .ToListAsync();

        //    // Select only the necessary properties and convert to WeigthDto
        //    var weigthDtos = weigths.Select(z => z.ToWeigthDtoFromWeigth()).ToList();

        //    // Order the selected entities by RegistrationDate in descending order
        //    weigthDtos = weigthDtos.OrderByDescending(x => x.RegistrationDate).ToList();

        //    // Limit the result set to the last 7 entities
        //    weigthDtos = weigthDtos.Take(7).ToList();

        //    return weigthDtos;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="weigth"></param>
        ///// <returns></returns>
        //public async Task<Weigths> CreateAsync(Weigths weigth)
        //{
        //    await _context.Weigths.AddAsync(weigth);
        //    await _context.SaveChangesAsync();

        //    return weigth;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        ///// <exception cref="NotFoundException"></exception>
        //public async Task<Weigths> DeleteAsync(int id)
        //{
        //    Weigths? Weigths = await _context.Weigths.FindAsync(id);

        //    if (Weigths is null)
        //    {
        //        throw new NotFoundException("Weigths not found");
        //    }
        //    else
        //    {
        //        Weigths.UpdatedDate = DateTime.Now;
        //        Weigths.IsActive = false;

        //        try
        //        {
        //            _context.Entry(Weigths).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //    }

        //    return Weigths;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="weigth"></param>
        ///// <returns></returns>
        ///// <exception cref="NotFoundException"></exception>
        //public async Task<Weigths> UpdateAsync(int id, Weigths weigth)
        //{
        //    var existingWeigth = await _context
        //       .Weigths
        //       .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

        //    if (existingWeigth == null)
        //    {
        //        throw new NotFoundException("Weigths not found");
        //    }

        //    existingWeigth.UpdatedDate = DateTime.UtcNow;
        //    existingWeigth.Description = weigth.Description;
        //    existingWeigth.RegistrationDate = weigth.RegistrationDate;
        //    existingWeigth.Kg = weigth.Kg;

        //    try
        //    {
        //        _context.Entry(existingWeigth).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return existingWeigth;
        //}
    }
}