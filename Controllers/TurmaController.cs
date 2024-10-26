using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Contexts;
using Desafio_Marlin.DTOs;
using Desafio_Marlin.Entities;
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
            var turma = new Turma{
                Codigo = turmaDTO.Codigo,
                Nivel = turmaDTO.Nivel
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
        [HttpGet("TurmaCPF/{cpf}")]
        public IActionResult ObterCpfTurma(string cpf){
            var Turma = _ctxt.Turmas.FirstOrDefault(x => x.Cpf == cpf);

            if(Turma == null)
                return NotFound();

            return Ok(Turma);
        }
        [HttpGet("TurmaNome/{nome}")]
        public IActionResult ObterNomeTurmas(string nome){
            var Turma = _ctxt.Turmas.Where(x => x.Nome.Contains(nome)).ToList();

            if(Turma == null)
                return NotFound();

            return Ok(Turma);
        }
    }
}