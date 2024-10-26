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
            if (_ctxt.Matriculas.Any(m => m.AlunoId == alunoId && m.TurmaId == turmaId))
                return BadRequest("Aluno já matriculado nesta turma!");

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