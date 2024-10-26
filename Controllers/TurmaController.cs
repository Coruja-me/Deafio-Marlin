using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Marlin.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Marlin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController(CursoContext ctxt) : ControllerBase
    {
        private readonly CursoContext _ctxt = ctxt;
    }
}