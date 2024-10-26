using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Enuns;

namespace Desafio_Marlin.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public Generos Genero { get; set; }
        public string Email { get; set; }

        public ICollection<Matricula> Matriculas { get; set; } = [];
    }
}