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
            partners = await _partnerRepository.CreatePartnersAsync(partners);


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
    }
}