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
        private readonly IRepository<Provento> _repoProvento;
        private readonly IRepository<CotacaoPorLoteMil> _repoCotacaoPorLoteMil;
        private readonly ILogger<ObterProventosHandler> _logger;

        public ObterProventosHandler(IRepository<Provento> repoProvento, IRepository<CotacaoPorLoteMil> repoCotacaoPorLoteMil, ILogger<ObterProventosHandler> logger)
        {
            _repoProvento = repoProvento;
            _repoCotacaoPorLoteMil = repoCotacaoPorLoteMil;
            _logger = logger;
        }
        public async Task<BaseResponseDto<List<ProventoDto>>> Handle(ObterProventosRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseDto<List<ProventoDto>>();
            try
            {
                var proventos = (await _repoProvento.GetAllAsync()).Select(p => new ProventoDto
                {
                    Aprovacao = p.Aprovacao,
                    Preco = p.Preco,
                    ProventoPorUnidade = p.ProventoPorUnidade,
                    Valor = p.Valor,
                    TipoProvento = (TipoProvento)p.TipoProventoId,
                    TipoAtivo = (TipoAtivo)p.TipoAtivoId,
                    CotacaoPorLoteMilId = p.CotacaoPorLoteMilId
                   
                }).ToList();

                var cotacoes = (await _repoCotacaoPorLoteMil.GetAllAsync()).Select(p => new CotacaoPorLoteMilDto
                {
                    PrecoPorUnidade = p.PrecoPorUnidade,
                    UltimoDia = p.UltimoDia,
                    UltimoDiaPreco = p.UltimoDiaPreco,
                    UltimoPreco = p.UltimoPreco,
                    Id = p.Id

                }).ToList();

                proventos.ForEach(p =>
                {
                    var cotacao = cotacoes.Find(c => c.Id == p.CotacaoPorLoteMilId);
                    if(cotacao != default)
                    {
                        p.CotacaoPorLoteMilDto = cotacao;                       
                    }                    
                });
                response.Data = proventos;                      

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("Falha ao listar os proventos.");
            }

            return response;
        }

        //public List<ProventoDto> CarregarProventos()
        //{
        //    return new List<ProventoDto>()
        //    {
        //        new ProventoDto()
        //        {
        //            Aprovacao = DateTime.UtcNow,
        //            Preco = decimal.Round(1,2),
        //            ProventoPorUnidade = 1,
        //            TipoAtivo =  TipoAtivo.ON.GetDescription(),
        //            TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
        //            Valor = decimal.Round(1,2),
        //            CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
        //            {
        //                PrecoPorUnidade = 1,
        //                UltimoDia = DateTime.UtcNow,
        //                UltimoDiaPreco = DateTime.UtcNow,
        //                UltimoPreco = decimal.Round(1,2),
        //            }

        //        },
        //        new ProventoDto()
        //        {
        //            Aprovacao = DateTime.UtcNow,
        //            Preco = decimal.Round(1,2),
        //            ProventoPorUnidade = 1,
        //            TipoAtivo = TipoAtivo.ON.GetDescription(),
        //            TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
        //            Valor = decimal.Round(1,2),
        //            CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
        //            {
        //                PrecoPorUnidade = 1,
        //                UltimoDia = DateTime.UtcNow,
        //                UltimoDiaPreco = DateTime.UtcNow,
        //                UltimoPreco = decimal.Round(1,2),
        //            }

        //        },
        //        new ProventoDto()
        //        {
        //            Aprovacao = DateTime.UtcNow,
        //            Preco = decimal.Round(1,2),
        //            ProventoPorUnidade = 1,
        //            TipoAtivo = TipoAtivo.ON.GetDescription(),
        //            TipoProvento = TipoProvento.JRSCAPPROPRIO.GetDescription(),
        //            Valor = decimal.Round(1,2),
        //            CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
        //            {
        //                PrecoPorUnidade = 1,
        //                UltimoDia = DateTime.UtcNow,
        //                UltimoDiaPreco = DateTime.UtcNow,
        //                UltimoPreco = decimal.Round(1,2),
        //            }

        //        },
        //        new ProventoDto()
        //        {
        //            Aprovacao = DateTime.UtcNow,
        //            Preco = decimal.Round(1,2),
        //            ProventoPorUnidade = 1,
        //            TipoAtivo = TipoAtivo.ON.GetDescription(),
        //            TipoProvento = TipoProvento.DIVIDENDO.GetDescription(),
        //            Valor =decimal.Round(1,2),
        //            CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
        //            {
        //                PrecoPorUnidade = 1,
        //                UltimoDia = DateTime.UtcNow,
        //                UltimoDiaPreco = DateTime.UtcNow,
        //                UltimoPreco = decimal.Round(1,2),
        //            }

        //        },
        //        new ProventoDto()
        //        {
        //            Aprovacao = DateTime.UtcNow,
        //            Preco = decimal.Round(1,2),
        //            ProventoPorUnidade = 1,
        //            TipoAtivo = TipoAtivo.ON.GetDescription(),
        //            TipoProvento = TipoProvento.DIVIDENDO.GetDescription(),
        //            Valor = decimal.Round(1,2),
        //            CotacaoPorLoteMilDto = new CotacaoPorLoteMilDto()
        //            {
        //                PrecoPorUnidade = 1,
        //                UltimoDia = DateTime.UtcNow,
        //                UltimoDiaPreco = DateTime.UtcNow,
        //                UltimoPreco = decimal.Round(1,2),
        //            }

        //        }
        //    };
        //}
    }
}