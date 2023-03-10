using codeChallenge.Application.Handlers.V1.Partners.Create.Dtos;

namespace codeChallenge.Application.Handlers.V1.Partners.GetPartnerByCoordinates
{
    public class GetPartnerByCoordinatesResponse
    {
        public string Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public CoverageAreaDto CoverageArea { get; set; }
        public AddressDto Address { get; set; }
    }
}