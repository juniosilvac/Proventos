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
        public string TipoAtivo { get; set; }
        public string TipoProvento { get; set; }

        public CotacaoPorLoteMilDto CotacaoPorLoteMilDto { get; set; }
    }
}