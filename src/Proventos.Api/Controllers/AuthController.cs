using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proventos.Core.Dtos.Requests;
using System.Threading.Tasks;

namespace Proventos.Api.Controllers
{
    [Route("v1/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Post([FromBody] AutenticarLoginRequest request)
        {
            var autenticarLoginRequest = await _mediator.Send(request);

            if (!autenticarLoginRequest.HasError)
            {
                return Ok(autenticarLoginRequest.Data);
            }
            else
            {
                return BadRequest(autenticarLoginRequest.Errors);
            }
        }
    }
}
