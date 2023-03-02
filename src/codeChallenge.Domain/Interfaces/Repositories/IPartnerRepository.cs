using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface IPartnerRepository
    {
        Task<Partner> CreatePartnerAsync(Partner partner);
        Task<Partner> GetPartnerByIdAsync(int id);
        Task<Partner> GetPartnerByAreaAsync(double longitude, double latitude);
        Task<Partner> GetPartnerByDocumentAsync(long document);        
    }
}