using System;
using System.Collections.Generic;
using System.Text;

namespace Proventos.Core.Models
{
    public class Usuario : EntityBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

