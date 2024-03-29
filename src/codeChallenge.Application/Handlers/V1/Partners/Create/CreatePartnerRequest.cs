using codeChallenge.Application.Handlers.V1.Partners.Create.Dtos;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Create
{
    public class CreatePartnerRequest : IRequest<CreatePartnerResponse>
    {
        public string Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public CoverageAreaDto CoverageArea { get; set; }
        public AddressDto Address { get; set; }
    }
}