using MediatR;

namespace codeChallenge.Application.Handlers.V1.Partners.GetPartnerByCoordinates
{
    public class GetPartnerByCoordinatesRequest : IRequest<GetPartnerByCoordinatesResponse>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}