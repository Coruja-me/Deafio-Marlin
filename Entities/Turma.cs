using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Enuns;

namespace Desafio_Marlin.Entities
{
    public class Turma
    {
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public Periodos Periodo { get; set; }

        public ICollection<Matricula> Matriculas { get; set; } = [];
    }
}