using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Contexts;
using Desafio_Marlin.DTOs;
using Desafio_Marlin.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Marlin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;
        
        [HttpPost("RealizarMatricula")]
        public IActionResult Matricular(MatriculaDTO matriculaDTO){
            var aluno = _ctxt.Alunos.Find(matriculaDTO.AlunoId);
            var turma = _ctxt.Turmas.Include(t => t.Matriculas).FirstOrDefault(t => t.Id == matriculaDTO.TurmaId);
            
            //Erros
            if (_ctxt.Matriculas.Any(m => m.AlunoId == matriculaDTO.AlunoId && m.TurmaId == matriculaDTO.TurmaId))
                return BadRequest("Aluno já matriculado nesta turma!");
            if(aluno == null)
                return NotFound("Aluno não encontrado!");
            if(turma == null)
                return NotFound("Turma não encontrada!");
            if(turma.Matriculas.Count >= 5)
                return BadRequest("Turma cheia, apenas 5 alunos permitidos!");


            var matricula = new Matricula{
                AlunoId = matriculaDTO.AlunoId,
                TurmaId = matriculaDTO.TurmaId,
                Aluno = aluno,
                Turma = turma
            };

            _ctxt.Matriculas.Add(matricula);
            _ctxt.SaveChanges();
            return CreatedAtAction(nameof(ObterIdMatricula), new {id = matricula.Id}, matriculaDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<Matricula> ObterIdMatricula(int id){
            var matricula = _ctxt.Matriculas.Find(id);
            if (matricula == null)
                return NotFound();
            
            return Ok(matricula);
        }
        [HttpDelete("DeletarMatricula/{id}")]
        public IActionResult DeletarMatricula(int id){
            var matricula = _ctxt.Matriculas.Find(id);

            if(matricula == null)
                return NotFound();
            
            _ctxt.Matriculas.Remove(matricula);
            _ctxt.SaveChanges();
            
            return NoContent();
        }
    }
}