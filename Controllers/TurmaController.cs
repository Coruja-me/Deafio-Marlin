using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Contexts;
using Desafio_Marlin.DTOs;
using Desafio_Marlin.Entities;
using Desafio_Marlin.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Marlin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;

        [HttpPost("CriarTurma")]
        public IActionResult CriarTurma(TurmaDTO turmaDTO){
            if (turmaDTO.Codigo.Length > 3)
                return BadRequest("O código não pode passar de 3 caracteres!");
    
            var turma = new Turma{
                Codigo = turmaDTO.Codigo.ToUpper(),
                Nome = turmaDTO.Nome,
                Nivel = turmaDTO.Nivel,
                Periodo = turmaDTO.Periodo
            };
            
            _ctxt.Add(turma);
            _ctxt.SaveChanges();

            return CreatedAtAction(nameof(ObterIdTurma), new {id = turma.Id}, turma);
        }
        
        [HttpGet("ListarTurmas")]
        public ActionResult<List<Turma>> ListarTodosTurmas(){
            var turmas = _ctxt.Turmas.ToList();
            if(turmas == null || turmas.Count == 0)
                return NotFound();

            return Ok(turmas);
        }

        [HttpGet("TurmaID/{Id}")]
        public IActionResult ObterIdTurma(int id){
            var Turma = _ctxt.Turmas.Find(id);

            if(Turma == null)
                return NotFound();

            return Ok(Turma);
        }
        [HttpGet("TurmaCod/{codigo}")]
        public IActionResult ObterCpfTurma(string codigo){
            var turma = _ctxt.Turmas.Where(x => x.Codigo.Contains(codigo));

            if(turma == null)
                return NotFound();

            return Ok(turma);
        }
        [HttpGet("TurmaNivel/{nivel}")]
        public IActionResult ObterNomeTurmas(string nivel){
            var turma = _ctxt.Turmas.Where(x => x.Nivel.Contains(nivel)).ToList();

            if(turma == null)
                return NotFound();

            return Ok(turma);
        }
        [HttpGet("TurmaPeriodo/{periodo}")]
        public IActionResult ObterPeriodosTurmas(Periodos periodo){
            var turma = _ctxt.Turmas.Where(x => x.Periodo == periodo).ToList();

            if(turma == null)
                return NotFound();

            return Ok(turma);
        }

        [HttpDelete("DeletarTurma/{id}")]
        public IActionResult DeletarAluno(int id){
            var turma = _ctxt.Turmas.Find(id);

            if(turma == null)
                return NotFound();
            if(turma.Matriculas.Count > 0){
                return BadRequest("Não é possível deletar uma turma que possua um aluno matriculado!");
            }
            
            _ctxt.Turmas.Remove(turma);
            _ctxt.SaveChanges();
            
            return NoContent();
        }
    }
}