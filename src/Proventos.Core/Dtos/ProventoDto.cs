using Proventos.Core.Models.Enums;
using System;

namespace Proventos.Core.Dtos
{
    public class ProventoDto
    {
        public ProventoDto()
        {            
        }

        public DateTime Aprovacao { get; set; }
        public decimal Valor { get; set; }
        public decimal Preco { get; set; }
        public int ProventoPorUnidade { get; set; }
        public TipoAtivo  TipoAtivo { get; set; }
        public TipoProvento TipoProvento { get; set; }

        public Guid CotacaoPorLoteMilId { get; set; }

        public CotacaoPorLoteMilDto CotacaoPorLoteMilDto { get; set; }
    }
}