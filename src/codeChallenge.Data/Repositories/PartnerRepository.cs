using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Helpers;
using codeChallenge.Domain.Interfaces;
using codeChallenge.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace codeChallenge.Data.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly ICodeChallengeContext _context;

        public PartnerRepository(ICodeChallengeContext codeChallengeContext)
        {
            _context = codeChallengeContext;
        }

        public async Task<Partner> CreatePartnerAsync(Partner partner)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreatePartnersAsync(List<Partner> partners)
        {
            try
            {
                await _context.Partners.InsertManyAsync(partners);
                return true;
            }
            catch (Exception e)
            {
                var erro = e.Message;
                return false;
            }
        }


        public async Task<Partner> GetClosestPartnerByAreaAsync(double longitude, double latitude)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<Partner>.Filter.GeoIntersects("coverageArea", point);

            var foundPartners = await _context.Partners.Find(filter).ToListAsync();

            if (foundPartners == null || !foundPartners.Any())
                return null;

            var closestPartner = foundPartners
                .OrderBy(p => GeoHelpers.Distance(p.Address, point))
                .FirstOrDefault();

            return closestPartner;
        }
        public async Task<Partner> GetPartnerByDocumentAsync(string document)
        {
            FilterDefinition<Partner> filter = Builders<Partner>.Filter.ElemMatch(p => p.Document, document);

            return (await _context.Partners.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Partner> GetPartnerByIdAsync(string id)
        {
            return (await _context.Partners.FindAsync(p => p.Id == id)).FirstOrDefault();
        }
    }
}