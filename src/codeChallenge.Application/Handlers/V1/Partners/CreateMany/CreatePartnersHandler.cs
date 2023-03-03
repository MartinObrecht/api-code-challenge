using System.Text.Json;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Extensions;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.CreateMany
{
    public class CreatePartnersHandler : IRequestHandler<CreatePartnersRequest, CreatePartnersResponse>
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ICoverageAreaRepository _coverageAreaRepository;
        private readonly IAddressRepository _addressRepository;

        public CreatePartnersHandler(IPartnerRepository partnerRepository, ICoverageAreaRepository coverageAreaRepository, IAddressRepository addressRepository)
        {
            _partnerRepository = partnerRepository;
            _coverageAreaRepository = coverageAreaRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CreatePartnersResponse> Handle(CreatePartnersRequest request, CancellationToken cancellationToken)
        {
            List<Partner> partners = new List<Partner>();
            List<CoverageArea> coverageAreas = new List<CoverageArea>();
            List<Address> addresses = new List<Address>();

            BuildPartners(request, partners);
            partners = await _partnerRepository.CreatePartnersAsync(partners);

            coverageAreas = BuildCoverageArea(request, coverageAreas, partners);
            addresses = BuildAddress(request, addresses, partners);

            await _coverageAreaRepository.CreateCoverageAreasAsync(coverageAreas);
            await _addressRepository.CreateAddressesAsync(addresses);


            return new CreatePartnersResponse { Success = true, StatusCode = 201, Message = $"{partners.Count} Partners Created" };
        }

        private static List<Partner> BuildPartners(CreatePartnersRequest request, List<Partner> partners)
        {
            foreach (var partner in request.Partners)
            {
                partners.Add(
                    new Partner
                    {
                        TradingName = partner.TradingName,
                        OwnerName = partner.OwnerName,
                        Document = partner.Document.OnlyNumbers().ToLong()
                    });
            }

            return partners;
        }

        private static List<CoverageArea> BuildCoverageArea(CreatePartnersRequest request, List<CoverageArea> coverageAreas, List<Partner> partners)
        {
            foreach (var partner in request.Partners)
            {
                var partnerToBeUpadate = partners.FirstOrDefault(x => x.Id == partner.Id);
                if (partner.Id.Equals(partnerToBeUpadate.Id))
                {
                    coverageAreas.Add(
                        new CoverageArea
                        {
                            PartnerId = partnerToBeUpadate.Id,
                            Type = partner.CoverageArea.Type,
                            Coordinates = JsonSerializer.Serialize(partner.CoverageArea.Coordinates),
                        });
                }
            }

            return coverageAreas;
        }

        private static List<Address> BuildAddress(CreatePartnersRequest request, List<Address> addresses, List<Partner> partners)
        {
            foreach (var partner in request.Partners)
            {
                var partnerToBeUpadate = partners.FirstOrDefault(x => x.Id == partner.Id);
                if (partner.Id.Equals(partnerToBeUpadate.Id))
                {
                    addresses.Add(
                    new Address
                    {
                        Type = partner.Address.Type,
                        Longitude = partner.Address.Coordinates[0],
                        Latitude = partner.Address.Coordinates[1],
                        PartnerId = partner.Id,
                    });
                }
            }

            return addresses;
        }
    }
}