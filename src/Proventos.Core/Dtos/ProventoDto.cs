using System;

namespace Proventos.Core.Dtos
{
    public class ProventoDto
    {        
         public DateTime Aprovacao { get; set;}
         public decimal Valor {get; set;}
         public decimal Preco {get; set;}
         public int ProventoPorUnidade {get; set;}         
    }
}