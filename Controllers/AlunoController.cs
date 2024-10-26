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
    public class AlunoController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;

        [HttpPost("CriarAluno")]
        public IActionResult CriarAluno(Aluno aluno){
            _ctxt.Add(aluno);
            _ctxt.SaveChanges();
            return CreatedAtAction(nameof(ObterIdAluno), new {id = aluno.Id}, aluno);
        }
        
        [HttpGet("ListaAlunos")]
        public ActionResult<List<Aluno>> ListaAlunos(){
            var alunos = _ctxt.Alunos.ToList();
            if(alunos == null || alunos.Count == 0)
                return NotFound();

            return Ok(alunos);
        }

        [HttpGet("AlunoID/{Id}")]
        public IActionResult ObterIdAluno(int id){
            var aluno = _ctxt.Alunos.Find(id);

            if(aluno == null)
                return NotFound();

            return Ok(aluno);
        }
        [HttpGet("AlunoCPF/{cpf}")]
        public IActionResult ObterCpfAluno(string cpf){
            var aluno = _ctxt.Alunos.FirstOrDefault(x => x.Cpf == cpf);

            if(aluno == null)
                return NotFound();

            return Ok(aluno);
        }
        [HttpGet("AlunoNome/{nome}")]
        public IActionResult ObterNomeAlunos(string nome){
            var aluno = _ctxt.Alunos.Where(x => x.Nome.Contains(nome));

            if(aluno == null)
                return NotFound();

            return Ok(aluno);
        }
    }
}