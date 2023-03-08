using System.Text.Json;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Queries
{
    public class GetPartnerByIdHandler : IRequestHandler<GetPartnerByIdRequest, GetPartnerByIdResponse>
    {
        private readonly IPartnerRepository _partnerRepository;

        public GetPartnerByIdHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<GetPartnerByIdResponse> Handle(GetPartnerByIdRequest request, CancellationToken cancellationToken)
        {
            Partner partner = await _partnerRepository.GetPartnerByIdAsync(request.PartnerId);

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
            };
        }
    }
}