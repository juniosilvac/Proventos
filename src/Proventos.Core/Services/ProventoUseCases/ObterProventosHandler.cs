using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Proventos.Core.Dtos;
using Proventos.Core.Dtos.Requests;
using Proventos.Core.Interfaces;
using Proventos.Core.Models;

namespace Proventos.Core.Services.ProventosUseCases
{
    public class ObterProventosHandler : IRequestHandler<ObterProventosRequest, BaseResponseDto<List<ProventoDto>>>
    {
        private readonly IRepository<Provento> _repository;
        private readonly ILogger<ObterProventosHandler> _logger;

        public ObterProventosHandler(IRepository<Provento> repository, ILogger<ObterProventosHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<BaseResponseDto<List<ProventoDto>>> Handle(ObterProventosRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseDto<List<ProventoDto>>();
            try
            {
                var proventos = (await _repository.GetAllAsync()).Select(p => new ProventoDto
                {
                    Aprovacao = p.Aprovacao,
                    Preco = p.Preco,
                    ProventoPorUnidade = p.ProventoPorUnidade,
                    Valor = p.Valor                
                }).ToList();
                response.Data = proventos;                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Erros.Add("Falha ao listar os proventos.");
            }

            return response;
        }
    }
}