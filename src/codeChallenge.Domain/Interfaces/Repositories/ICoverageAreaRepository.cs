using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface ICoverageAreaRepository
    {
        Task<CoverageArea> CreateCoverageAreaAsync(CoverageArea address);
        Task<List<CoverageArea>> CreateCoverageAreasAsync(List<CoverageArea> coverageAreas);
        Task<CoverageArea> GetCoverageAreaByPartnerId(int partnerId);
    }
}