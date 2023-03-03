using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address address);
        Task<List<Address>> CreateAddressesAsync(List<Address> addresses);
        Task<Address> GetAddressByPartnerId(int partnerId);
    }
}