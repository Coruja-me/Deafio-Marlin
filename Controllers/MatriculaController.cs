using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Contexts;
using Desafio_Marlin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Marlin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;
        
        [HttpPost("RealizarMatricula")]
        public IActionResult Matricular(int alunoId, int turmaId){
            var aluno = _ctxt.Alunos.Find(alunoId);
            var turma = _ctxt.Turmas.Find(turmaId);
            
            //Erros
            if (_ctxt.Matriculas.Any(m => m.AlunoId == alunoId && m.TurmaId == turmaId))
                return BadRequest("Aluno já matriculado nesta turma!");
            if(aluno == null)
                return NotFound("Aluno não encontrado!");
            if(turma == null)
                return NotFound("Turma não encontrada!");
            if(turma.Matriculas.Count >= 5)
                return BadRequest("Turma cheia, apenas 5 alunos permitidos!");


            var matricula = new Matricula{
                AlunoId = alunoId,
                TurmaId = turmaId
            };

            _ctxt.Matriculas.Add(matricula);
            _ctxt.SaveChanges();
            return CreatedAtAction(nameof(ObterIdMatricula), new {id = matricula.Id}, matricula);
        }
        [HttpGet("{id}")]
        public ActionResult<Matricula> ObterIdMatricula(int id){
            var matricula = _ctxt.Matriculas.Find(id);
            if (matricula == null)
                return NotFound();
            
            return matricula;
        }
    }
}