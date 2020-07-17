using System;

namespace Proventos.Core.Models
{
    public class Provento : EntityBase
    {
        public DateTime Aprovacao { get; set; }
        public decimal Valor { get; set; }
        public decimal Preco { get; set; }
        public int ProventoPorUnidade { get; set; }
        public int TipoProventoId { get; set; }

        public int TipoAtivoId { get; set; }

        public Guid CotacaoPorLoteMilId { get; set; }
    }
}