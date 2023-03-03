using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.Queries
{
    public class GetPartnerByIdRequest : IRequest<GetPartnerByIdResponse>
    {
        public int PartnerId { get; set; }
    }
}