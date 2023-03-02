using System.Text.Json;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Extensions;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Create
{
    public class CreatePartnerHandler : IRequestHandler<CreatePartnerRequest, CreatePartnerResponse>
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ICoverageAreaRepository _coverageAreaRepository;
        private readonly IAddressRepository _addressRepository;

        public CreatePartnerHandler(IPartnerRepository partnerRepository, ICoverageAreaRepository coverageAreaRepository, IAddressRepository addressRepository)
        {
            _partnerRepository = partnerRepository;
            _coverageAreaRepository = coverageAreaRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {

            Partner partner = new Partner
            {
                TradingName = request.TradingName,
                OwnerName = request.OwnerName,
                Document = request.Document.OnlyNumbers().ToLong(),
            };
            
            partner = await _partnerRepository.CreatePartnerAsync(partner);

            CoverageArea coverageArea = new CoverageArea
            {
                PartnerId = partner.Id,
                Type = request.CoverageArea.Type,
                Coordinates = JsonSerializer.Serialize(request.CoverageArea.Coordinates)
            };

            Address address = new Address
            {
                Type = request.Address.Type,
                Longitude = request.Address.Coordinates[0],
                Latitude = request.Address.Coordinates[1],
                PartnerId = partner.Id
            };

            await _coverageAreaRepository.CreateCoverageAreaAsync(coverageArea);
            await _addressRepository.CreateAddressAsync(address);

            return new CreatePartnerResponse { Sucess = true, StatusCode = 201,  Message = "Partner Created"};
        }
    }
}