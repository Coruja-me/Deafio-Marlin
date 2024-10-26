using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Marlin.Entities
{
    public class Turma
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nivel { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}