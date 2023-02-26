using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partner.Create
{
    public class CreatePartnerHandler : IRequestHandler<CreatePartnerRequest, CreatePartnerResponse>
    {
        public Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}