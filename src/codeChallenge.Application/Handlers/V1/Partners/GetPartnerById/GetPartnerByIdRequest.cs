using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.GetPartnerById
{
    public class GetPartnerByIdRequest : IRequest<GetPartnerByIdResponse>
    {
        public string PartnerId { get; set; }
    }
}