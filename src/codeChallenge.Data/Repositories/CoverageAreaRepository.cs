using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;

namespace codeChallenge.Data.Repositories
{
    public class CoverageAreaRepository : ICoverageAreaRepository
    {
        private readonly CodeChallengeContext _context;

        public CoverageAreaRepository(CodeChallengeContext context)
        {
            _context = context;
        }

        public async Task<CoverageArea> CreateCoverageAreaAsync(CoverageArea coverageArea)
        {
            await _context.CoverageArea.AddAsync(coverageArea);
            await _context.SaveChangesAsync();

            return coverageArea;
        }

        public async Task<List<CoverageArea>> CreateCoverageAreasAsync(List<CoverageArea> coverageAreas)
        {
            await _context.CoverageArea.AddRangeAsync(coverageAreas);
            await _context.SaveChangesAsync();

            return coverageAreas;
        }
    }
}