using MediatR;

namespace Proventos.Core.Dtos.Requests
{
    public class AutenticarLoginRequest : IRequest<BaseResponseDto<Token>>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
