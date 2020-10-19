using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly IDiretorAppService _diretorAppService;

        public DiretoresController(IDiretorAppService diretorAppService)
        {
            _diretorAppService = diretorAppService;
        }

        // GET: api/Diretores
        [HttpGet]
        public async Task<IActionResult> GetDiretores()
        {
            var diretores = await _diretorAppService.ObterTodos();
            return Ok(diretores);
        }

        // GET: api/Diretores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiretor(Guid id)
        {
            var diretor = await _diretorAppService.ObterPorId(id);

            if (diretor == null)
            {
                return NotFound();
            }

            return Ok(diretor);
        }        

        // POST: api/Diretores
        [HttpPost]
        public async Task<IActionResult> PostDiretor(DiretorViewModel diretor)
        {
            var retornoDiretor = await _diretorAppService.Adicionar(diretor);
            return CreatedAtAction("GetDiretor", new { id = retornoDiretor.IdDiretor }, retornoDiretor);
        }
  
    }
}
