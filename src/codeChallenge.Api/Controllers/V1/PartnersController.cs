using codeChallenge.Application.Handlers.V1.Partners.CreateMany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace codeChallenge.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PartnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartners([FromBody]CreatePartnersRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}