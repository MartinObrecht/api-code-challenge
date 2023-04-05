using codeChallenge.Application.Handlers.V1.Partners.Create;
using codeChallenge.Application.Handlers.V1.Partners.GetPartnerByCoordinates;
using codeChallenge.Application.Handlers.V1.Partners.GetPartnerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace codeChallenge.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner([FromBody] CreatePartnerRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{partnerId}")]
        public async Task<IActionResult> GetPartnerById([FromRoute] string partnerId)
        {
            var result = await _mediator.Send(new GetPartnerByIdRequest { PartnerId = partnerId });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClosestPartnerByArea(
            [FromQuery] double longitude,
            [FromQuery] double latitude)
        {
            var request = new GetPartnerByCoordinatesRequest
            {
                Longitude = longitude,
                Latitude = latitude
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}