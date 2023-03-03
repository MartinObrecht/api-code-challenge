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

        public CreatePartnerHandler(IPartnerRepository partnerRepository, 
                                    ICoverageAreaRepository coverageAreaRepository,
                                    IAddressRepository addressRepository)
        {
            _partnerRepository = partnerRepository;
            _coverageAreaRepository = coverageAreaRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            Partner partner = BuildPartner(request);
            partner = await _partnerRepository.CreatePartnerAsync(partner);

            CoverageArea coverageArea = BuildCoverageArea(request, partner.Id);

            Address address = BuildAddress(request, partner.Id);
            
            await _coverageAreaRepository.CreateCoverageAreaAsync(coverageArea);
            await _addressRepository.CreateAddressAsync(address);

            return new CreatePartnerResponse { Success = true, StatusCode = 201, Message = "Partner Created" };
        }
        
        private static Partner BuildPartner(CreatePartnerRequest request) =>
            new Partner
            {
                TradingName = request.TradingName,
                OwnerName = request.OwnerName,
                Document = request.Document.OnlyNumbers().ToLong(),
            };
        
        private static CoverageArea BuildCoverageArea(CreatePartnerRequest request, int partnerId) =>
            new CoverageArea
            {
                PartnerId = partnerId,
                Type = request.CoverageArea.Type,
                Coordinates = JsonSerializer.Serialize(request.CoverageArea.Coordinates),
            };
        
        private static Address BuildAddress(CreatePartnerRequest request, int partnerId) =>
            new Address
            {
                Type = request.Address.Type,
                Coordinates = JsonSerializer.Serialize(request.Address.Coordinates),
                PartnerId = partnerId,
            };

    }
}
