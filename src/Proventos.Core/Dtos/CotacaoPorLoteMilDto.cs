﻿using System;

namespace Proventos.Core.Dtos
{
    public class CotacaoPorLoteMilDto
    {
        public Guid Id { get; set; }
        public DateTime UltimoDia { get; set; }
        public DateTime UltimoDiaPreco { get; set; }
        public decimal UltimoPreco { get; set; }
        public int PrecoPorUnidade { get; set; }
    }
}
