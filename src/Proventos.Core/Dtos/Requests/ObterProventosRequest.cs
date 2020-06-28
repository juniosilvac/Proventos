using System.Collections.Generic;
using MediatR;

namespace Proventos.Core.Dtos.Requests
{
    public class ObterProventosRequest : IRequest<BaseResponseDto<List<ProventoDto>>>
    {

    }
}
