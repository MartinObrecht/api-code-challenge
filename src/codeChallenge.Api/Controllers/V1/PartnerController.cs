using codeChallenge.Application.Handlers.V1.Partners.Create;
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
    }
}