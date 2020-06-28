using System;

namespace Proventos.Core.Models
{
    public class Provento : EntityBase
    {
      public DateTime Aprovacao { get; set;}
      public decimal Valor {get; set;}
      public decimal Preco {get; set;}
      public int ProventoPorUnidade {get; set;}
    }
}