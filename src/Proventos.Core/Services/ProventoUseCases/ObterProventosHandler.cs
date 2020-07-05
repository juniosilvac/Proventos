using MediatR;
using Microsoft.Extensions.Logging;
using Proventos.Core.Dtos;
using Proventos.Core.Dtos.Requests;
using Proventos.Core.Extensions;
using Proventos.Core.Interfaces;
using Proventos.Core.Models;
using Proventos.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Proventos.Core.Services.ProventoUseCases
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
                response.Data = CarregarProventos();//proventos;                      

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("Falha ao listar os proventos.");
            }

            return response;
        }

        public List<ProventoDto> CarregarProventos()
        {
            return new List<ProventoDto>()
            {
                new ProventoDto()
                {
                    Aprovacao = DateTime.UtcNow,
                    Preco = decimal.Round(1,2),
                    ProventoPorUnidade = 1,
                    TipoAtivo =  TipoAtivo.ON.GetDescription(),
                    TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
                    Valor = decimal.Round(1,2),
                    CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
                    {
                        PrecoPorUnidade = 1,
                        UltimoDia = DateTime.UtcNow,
                        UltimoDiaPreco = DateTime.UtcNow,
                        UltimoPreco = decimal.Round(1,2),
                    }

                },
                new ProventoDto()
                {
                    Aprovacao = DateTime.UtcNow,
                    Preco = decimal.Round(1,2),
                    ProventoPorUnidade = 1,
                    TipoAtivo = TipoAtivo.ON.GetDescription(),
                    TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
                    Valor = decimal.Round(1,2),
                    CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
                    {
                        PrecoPorUnidade = 1,
                        UltimoDia = DateTime.UtcNow,
                        UltimoDiaPreco = DateTime.UtcNow,
                        UltimoPreco = decimal.Round(1,2),
                    }

                },
                new ProventoDto()
                {
                    Aprovacao = DateTime.UtcNow,
                    Preco = decimal.Round(1,2),
                    ProventoPorUnidade = 1,
                    TipoAtivo = TipoAtivo.ON.GetDescription(),
                    TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
                    Valor = decimal.Round(1,2),
                    CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
                    {
                        PrecoPorUnidade = 1,
                        UltimoDia = DateTime.UtcNow,
                        UltimoDiaPreco = DateTime.UtcNow,
                        UltimoPreco = decimal.Round(1,2),
                    }

                },
                new ProventoDto()
                {
                    Aprovacao = DateTime.UtcNow,
                    Preco = decimal.Round(1,2),
                    ProventoPorUnidade = 1,
                    TipoAtivo = TipoAtivo.ON.GetDescription(),
                    TipoProvento = TipoProvento.DIVIDENDO.GetDescription(),
                    Valor =decimal.Round(1,2),
                    CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
                    {
                        PrecoPorUnidade = 1,
                        UltimoDia = DateTime.UtcNow,
                        UltimoDiaPreco = DateTime.UtcNow,
                        UltimoPreco = decimal.Round(1,2),
                    }

                },
                new ProventoDto()
                {
                    Aprovacao = DateTime.UtcNow,
                    Preco = decimal.Round(1,2),
                    ProventoPorUnidade = 1,
                    TipoAtivo = TipoAtivo.ON.GetDescription(),
                    TipoProvento = TipoProvento.DIVIDENDO.GetDescription(),
                    Valor = decimal.Round(1,2),
                    CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
                    {
                        PrecoPorUnidade = 1,
                        UltimoDia = DateTime.UtcNow,
                        UltimoDiaPreco = DateTime.UtcNow,
                        UltimoPreco = decimal.Round(1,2),
                    }

                }
            };
        }
    }
}