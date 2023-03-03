using System.Collections.Generic;
using System.Text.Json;
using codeChallenge.Application.Handlers.V1.Partners.Create.Dtos;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Queries
{
    public class GetPartnerByIdHandler : IRequestHandler<GetPartnerByIdRequest, GetPartnerByIdResponse>
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ICoverageAreaRepository _coverageAreaRepository;
        private readonly IAddressRepository _addressRepository;

        public GetPartnerByIdHandler(IPartnerRepository partnerRepository, ICoverageAreaRepository coverageAreaRepository, IAddressRepository addressRepository)
        {
            _partnerRepository = partnerRepository;
            _coverageAreaRepository = coverageAreaRepository;
            _addressRepository = addressRepository;
        }

        public async Task<GetPartnerByIdResponse> Handle(GetPartnerByIdRequest request, CancellationToken cancellationToken)
        {
            Partner partner = await _partnerRepository.GetPartnerByIdAsync(request.PartnerId);
            CoverageArea coverageArea = await _coverageAreaRepository.GetCoverageAreaByPartnerId(request.PartnerId);
            Address address = await _addressRepository.GetAddressByPartnerId(request.PartnerId);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return new GetPartnerByIdResponse
            {
                Id = partner.Id,
                TradingName = partner.TradingName,
                OwnerName = partner.OwnerName,
                Document = partner.Document.ToString(),
                CoverageArea = new CoverageAreaDto
                {
                    Type = partner.CoverageArea.Type,
                    Coordinates = JsonSerializer.Deserialize<List<List<List<List<double>>>>>(partner.CoverageArea.Coordinates, options),
                },
                Address = new AddressDto
                {
                    Type = partner.Addres.Type,
                    Coordinates = JsonSerializer.Deserialize<List<double>>(partner.Addres.Coordinates, options),
                }
            };
        }
    }
}