using codeChallenge.Domain.Entities;

namespace codeChallenge.Domain.Interfaces.Repositories
{
    public interface ICoverageAreaRepository
    {
        Task<CoverageArea> CreateCoverageAreaAsync(CoverageArea address);        
    }
}