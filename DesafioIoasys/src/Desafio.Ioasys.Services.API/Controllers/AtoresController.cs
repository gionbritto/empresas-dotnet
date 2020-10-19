using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtoresController : ControllerBase
    {
        private readonly IAtorAppService _atorAppService;

        public AtoresController(IAtorAppService atorAppService)
        {
            _atorAppService = atorAppService;
        }

        // GET: api/Atores
        [HttpGet]
        public async Task<IActionResult> GetAtores()
        {
            var atores = await _atorAppService.ObterTodos();
            return Ok(atores);
        }

        // GET: api/Atores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtor(Guid id)
        {
            var ator = await _atorAppService.ObterPorId(id);

            if (ator == null)
            {
                return NotFound();
            }

            return Ok(ator);
        }        

        // POST: api/Atores
        [HttpPost]
        public async Task<IActionResult> PostAtor(AtorViewModel ator)
        {
            var retornoAtor = await _atorAppService.Adicionar(ator);
            return CreatedAtAction("GetAtor", new { id = retornoAtor.IdAtor }, retornoAtor);
        }
  
    }
}
