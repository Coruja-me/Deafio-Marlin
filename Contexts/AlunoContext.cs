using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Marlin.Contexts
{
    public class AlunoContext(DbContextOptions<AlunoContext> optAluno) : DbContext(optAluno)
    {
        public DbSet<Aluno> Alunos { get; set; }
    }
}