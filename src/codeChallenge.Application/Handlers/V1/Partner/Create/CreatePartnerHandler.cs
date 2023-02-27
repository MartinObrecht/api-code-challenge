using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partner.Create
{
    public class CreatePartnerHandler : IRequestHandler<CreatePartnerRequest, CreatePartnerResponse>
    {
        public async Task<CreatePartnerResponse> Handle(CreatePartnerRequest request, CancellationToken cancellationToken)
        {
            return new CreatePartnerResponse(); //throw new NotImplementedException();
        }
    }
}