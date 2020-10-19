using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroAppService _generoAppService;

        public GenerosController(IGeneroAppService generoAppService)
        {
            _generoAppService = generoAppService;
        }

        // GET: api/Generos
        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var generos = await _generoAppService.ObterTodos();
            return Ok(generos);
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenero(Guid id)
        {
            var genero = await _generoAppService.ObterPorId(id);

            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }        

        // POST: api/Generos
        [HttpPost]
        public async Task<IActionResult> PostGenero(GeneroViewModel genero)
        {
            var retornoGenero = await _generoAppService.Adicionar(genero);
            return CreatedAtAction("GetGenero", new { id = retornoGenero.IdGenero }, retornoGenero);
        }
  
    }
}
