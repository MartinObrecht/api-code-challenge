using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface IPartnerRepository
    {
        Task<Partner> CreatePartnerAsync(Partner partner);
        Task<bool> CreatePartnersAsync(List<Partner> partners);
        Task<Partner> GetPartnerByIdAsync(string id);
        Task<Partner> GetClosestPartnerByAreaAsync(double longitude, double latitude);
        Task<Partner> GetPartnerByDocumentAsync(string document);        
    }
}