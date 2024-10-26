using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Marlin.Contexts
{
    public class TurmaContext : DbContext
    {
        public TurmaContext(DbContextOptions<TurmaContext> optTurma) : base(optTurma){

        }
    }
}