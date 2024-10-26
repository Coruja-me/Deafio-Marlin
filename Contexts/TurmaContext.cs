using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Marlin.Contexts
{
    public class TurmaContext(DbContextOptions<TurmaContext> optTurma) : DbContext(optTurma)
    {
        public DbSet<Turma> Turmas { get; set; }
    }
}