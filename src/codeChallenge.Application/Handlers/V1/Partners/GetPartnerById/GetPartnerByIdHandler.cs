using codeChallenge.Application.Handlers.V1.Partners.Create.Dtos;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces.Repositories;
using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.GetPartnerById
{
  public class GetPartnerByIdHandler : IRequestHandler<GetPartnerByIdRequest, GetPartnerByIdResponse>
  {
    private readonly IPartnerRepository _partnerRepository;

    public GetPartnerByIdHandler(IPartnerRepository partnerRepository)
    {
        _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
    }

    public async Task<GetPartnerByIdResponse> Handle(GetPartnerByIdRequest request, CancellationToken cancellationToken)
    {
        var partner = await _partnerRepository.GetPartnerByIdAsync(request.PartnerId);
        if (partner == null) return new GetPartnerByIdResponse();

        return MapPartnerToPartnerDto(partner);
    }

    private GetPartnerByIdResponse MapPartnerToPartnerDto(Partner partner)
    {
       return new GetPartnerByIdResponse
       {
          Id = partner.Id,
          TradingName = partner.TradingName,
          OwnerName = partner.OwnerName,
          Document = partner.Document.ToString(),
          CoverageArea = new CoverageAreaDto { Type = partner.CoverageArea.Type, Coordinates = partner.CoverageArea.Coordinates},
          Address = new AddressDto { Type = partner.Address.Type, Coordinates = partner.Address.Coordinates}
       };
    }
  }
}
