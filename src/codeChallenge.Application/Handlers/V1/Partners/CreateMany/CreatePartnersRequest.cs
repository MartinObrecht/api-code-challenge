
using codeChallenge.Application.Handlers.V1.Partners.Create;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.CreateMany
{
    public class CreatePartnersRequest : IRequest<CreatePartnersResponse>
    {
        public List<CreatePartnerRequest> Partners { get; set; }
    }
}