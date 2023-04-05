using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Extensions;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.CreateMany
{
    public class CreatePartnersHandler : IRequestHandler<CreatePartnersRequest, CreatePartnersResponse>
    {
        private readonly IPartnerRepository _partnerRepository;

        public CreatePartnersHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }
        public async Task<CreatePartnersResponse> Handle(CreatePartnersRequest request, CancellationToken cancellationToken)
        {
            List<Partner> partners = new List<Partner>();

            BuildPartners(request, partners);
            bool success = await _partnerRepository.CreatePartnersAsync(partners);

            if (success)
            {
                return new CreatePartnersResponse { Success = true, StatusCode = 201, Message = $"{partners.Count} Partners Created" };
            }

            return new CreatePartnersResponse { Success = false, StatusCode = 200, Message = $"Partners not Created" };
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
                        Document = partner.Document.OnlyNumbers(),
                        CoverageArea = new CoverageArea { Type = partner.CoverageArea.Type, Coordinates = partner.CoverageArea.Coordinates },
                        Address = new Address { Type = partner.Address.Type, Coordinates = partner.Address.Coordinates }
                    });
            }

            return partners;
        }
    }
}