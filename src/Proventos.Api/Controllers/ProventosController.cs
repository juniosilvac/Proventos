using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proventos.Core.Dtos;
using Proventos.Core.Dtos.Requests;

namespace Proventos.Api.Controllers
{
    [Route("v1/proventos")]
    [ApiController]
    public class ProventosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProventosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProventoDto>>> Get()
        {
            var obterProventosRequest = await _mediator.Send(new ObterProventosRequest());

            if (!obterProventosRequest.HasError)
            {
                return Ok(obterProventosRequest.Data);
            }
            else
            {
                return BadRequest(obterProventosRequest.Errors);
            }
        }
    }
}