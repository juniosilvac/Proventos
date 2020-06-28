using System;
using Proventos.Core.Models.Enums;

namespace Proventos.Core.Models
{
    public class Provento : EntityBase
    {
      public DateTime Aprovacao { get; set;}
      public decimal Valor {get; set;}
      public decimal Preco {get; set;}
      public int ProventoPorUnidade {get; set;}
      public TipoProvento TipoProvento {get; set;}

      public TipoAtivo TipoAtivo {get; set;}

      public CotacaoPorLoteMil CotacaoPorLoteMil {get; set;}
    }
}