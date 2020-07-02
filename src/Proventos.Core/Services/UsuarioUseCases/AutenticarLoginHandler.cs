using MediatR;
using Microsoft.Extensions.Logging;
using Proventos.Core.Dtos;
using Proventos.Core.Dtos.Requests;
using Proventos.Core.Interfaces;
using Proventos.Core.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Proventos.Core.Services.UsuarioUseCases
{
    public class AutenticarLoginHandler : IRequestHandler<AutenticarLoginRequest, BaseResponseDto<Token>>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly ILogger<AutenticarLoginHandler> _logger;
        private readonly IJwtFactory _jwtFactory;

        public AutenticarLoginHandler(IRepository<Usuario> repository, ILogger<AutenticarLoginHandler> logger, IJwtFactory jwtFactory)
        {
            _repository = repository;
            _logger = logger;
            _jwtFactory = jwtFactory;
        }

        public async Task<BaseResponseDto<Token>> Handle(AutenticarLoginRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseDto<Token>();
            const string messageUserInvalid = "Usuário ou Senha inválido.";

            try
            {
                //if(string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Senha))
                //{
                //    response.Errors.Add(messageUserInvalid);
                //    return response;
                //}

                //var login = await _repository.FindWhereAsync(p => p.Login == request.Login && p.Senha == request.Senha);

                //if (login == default)
                //{
                //    response.Errors.Add(messageUserInvalid);
                //    return response;
                //}

                var login = new Usuario()
                {
                    Id = Guid.NewGuid(),
                    Login = "user.api"
                };

                response.Data = await _jwtFactory.GenerateEncodedToken(login.Id.ToString(), login.Login);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("Falha ao buscar o login.");
            }

            return response;
        }
    }
}
