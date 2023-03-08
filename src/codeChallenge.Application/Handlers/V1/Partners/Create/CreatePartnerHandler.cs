using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Extensions;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Create
{
    public class CreatePartnerHandler : IRequestHandler<CreatePartnerRequest, CreatePartnerResponse>
    {
        private readonly IPartnerRepository _partnerRepository;

        public CreatePartnerHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            Partner partner = BuildPartner(request);
            partner = await _partnerRepository.CreatePartnerAsync(partner);            

            return new CreatePartnerResponse { Success = true, StatusCode = 201, Message = "Partner Created" };
        }
        
        private static Partner BuildPartner(CreatePartnerRequest request) =>
            new Partner
            {
                TradingName = request.TradingName,
                OwnerName = request.OwnerName,
                Document = request.Document.OnlyNumbers().ToLong(),
            };
    }
}
