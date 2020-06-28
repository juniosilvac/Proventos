using System.Collections.Generic;
using System.Linq;

namespace Proventos.Core.Dtos
{
    public class BaseResponseDto<T>
    {
        public BaseResponseDto()
        {
            Erros = new List<string>();
        }
        public bool HasError => Erros.Any();
        public List<string> Erros {get; set;}
        public int Total {get; set;}
        public T Data {get; set;}        
    }
}