using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Enuns;

namespace Desafio_Marlin.DTOs
{
    public class TurmaDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public Periodos Periodo { get; set; }
    }
}