using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace codeChallenge.Data.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly CodeChallengeContext _context;

        public PartnerRepository(CodeChallengeContext context)
        {
            _context = context;
        }

        public async Task<Partner> CreatePartnerAsync(Partner partner)
        {
            await _context.Partner.AddAsync(partner);
            await _context.SaveChangesAsync();

            return partner;
        }

        public async Task<List<Partner>> CreatePartnersAsync(List<Partner> partners)
        {
            await _context.Partner.AddRangeAsync(partners);
            await _context.SaveChangesAsync();

            return partners;
        }

        public Task<Partner> GetPartnerByAreaAsync(double longitude, double latitude)
        {
            throw new NotImplementedException();
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            var partner = await _context.Partner?.FirstOrDefaultAsync(x => x.Id.Equals(id))!;

            return partner;
        }

        public async Task<Partner> GetPartnerByDocumentAsync(long document)
        {
            var partner = await _context.Partner?.FirstOrDefaultAsync(x => x.Document.Equals(document))!;

            return partner;
        }
    }
}