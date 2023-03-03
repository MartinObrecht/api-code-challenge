using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;

namespace codeChallenge.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CodeChallengeContext _context;

        public AddressRepository(CodeChallengeContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<List<Address>> CreateAddressesAsync(List<Address> addresses)
        {
            await _context.AddRangeAsync(addresses);
            await _context.SaveChangesAsync();
            
            return addresses;
        }
    }
}