using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address address);
    }
}