using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Enuns;

namespace Desafio_Marlin.DTOs
{
    public class AlunoDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Idade { get; set; }
        public Generos Genero { get; set; }
        public string Email { get; set; }
    }
}