using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Marlin.Contexts
{
    public class CursoContext(DbContextOptions<CursoContext> options) : DbContext(options)
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Matricula>()
            .HasKey(m => new { m.AlunoId, m.TurmaId });

        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Aluno)
            .WithMany(a => a.Matriculas)
            .HasForeignKey(m => m.AlunoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Turma)
            .WithMany(t => t.Matriculas)
            .HasForeignKey(m => m.TurmaId)
            .OnDelete(DeleteBehavior.Cascade);
    
        modelBuilder.Entity<Aluno>()
            .HasIndex(a => a.Cpf)
            .IsUnique();
        }
    }
}