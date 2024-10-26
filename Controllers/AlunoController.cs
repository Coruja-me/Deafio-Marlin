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
    public class AlunoController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;

        [HttpPost("CriarAluno")]
        public IActionResult CriarAluno(AlunoDTO alunoDTO){
            var aluno = new Aluno{
                Nome = alunoDTO.Nome,
                Cpf = alunoDTO.Cpf,
                Idade = alunoDTO.Idade,
                Email = alunoDTO.Email,
                Genero = alunoDTO.Genero
            };
            
            _ctxt.Add(aluno);
            _ctxt.SaveChanges();

            if (alunoDTO.TurmaId.HasValue){
                var matricula = new Matricula{
                    AlunoId = aluno.Id,
                    TurmaId = alunoDTO.TurmaId.Value
                };
                _ctxt.Matriculas.Add(matricula);
                _ctxt.SaveChanges();
            }
            return CreatedAtAction(nameof(ObterIdAluno), new {id = aluno.Id}, aluno);
        }
        
        [HttpGet("ListarAlunos")]
        public ActionResult<List<Aluno>> ListarTodosAlunos(){
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
            var aluno = _ctxt.Alunos.Where(x => x.Nome.Contains(nome)).ToList();

            if(aluno == null)
                return NotFound();

            return Ok(aluno);
        }
        [HttpPut("AtualizarAluno/{id}")]
        public IActionResult AtualizarAluno(int id, AlunoDTO aluno){
            var alunoDb = _ctxt.Alunos.Find(id);

            if(alunoDb == null)
                return NotFound();

            alunoDb.Nome = aluno.Nome;
            alunoDb.Cpf = aluno.Cpf;
            alunoDb.Idade = aluno.Idade;
            alunoDb.Genero = aluno.Genero;
            alunoDb.Email = aluno.Email;

            _ctxt.Alunos.Update(alunoDb);
            _ctxt.SaveChanges();


            return CreatedAtAction(nameof(ObterIdAluno), new {id = alunoDb.Id}, aluno); 
        }

        [HttpDelete("DeletarAluno/{id}")]
        public IActionResult DeletarAluno(int id){
            var aluno = _ctxt.Alunos.Find(id);

            if(aluno == null)
                return NotFound();
            
            _ctxt.Alunos.Remove(aluno);
            _ctxt.SaveChanges();
            
            return NoContent();
        }

    }
}