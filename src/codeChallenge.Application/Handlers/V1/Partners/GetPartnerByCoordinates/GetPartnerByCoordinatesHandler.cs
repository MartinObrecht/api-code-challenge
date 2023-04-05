
using codeChallenge.Application.Handlers.V1.Partners.Create.Dtos;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.GetPartnerByCoordinates
{
    public class GetPartnerByCoordinatesHandler : IRequestHandler<GetPartnerByCoordinatesRequest, GetPartnerByCoordinatesResponse>
    {
        private readonly IPartnerRepository _partnerRepository;

        public GetPartnerByCoordinatesHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<GetPartnerByCoordinatesResponse> Handle(GetPartnerByCoordinatesRequest request, CancellationToken cancellationToken)
        {
            var partner = await _partnerRepository.GetClosestPartnerByAreaAsync(request.Longitude, request.Latitude);
            if (partner == null) return new GetPartnerByCoordinatesResponse();

            return MapPartnerToPartnerDto(partner);

        }

        private GetPartnerByCoordinatesResponse MapPartnerToPartnerDto(Partner partner)
        {
            return new GetPartnerByCoordinatesResponse
            {
                Id = partner.Id,
                TradingName = partner.TradingName,
                OwnerName = partner.OwnerName,
                Document = partner.Document.ToString(),
                CoverageArea = new CoverageAreaDto { Type = partner.CoverageArea.Type, Coordinates = partner.CoverageArea.Coordinates },
                Address = new AddressDto { Type = partner.Address.Type, Coordinates = partner.Address.Coordinates }
            };
        }
    }
}