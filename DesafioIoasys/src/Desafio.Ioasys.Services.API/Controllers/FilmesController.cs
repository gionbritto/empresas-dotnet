using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Ioasys.Application.Interfaces.Services;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Application.ViewModels.Filmes;
using System.Linq;
using Desafio.Ioasys.Application.ViewModels.FIltros;
using System.Collections.Generic;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmesController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<IActionResult> GetFilmes()
        {
            var filmes = await _filmeAppService.ObterTodos();
            return Ok(filmes);
        }


        //// GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme(Guid id)
        {
            var filme = await _filmeAppService.ObterPorId(id);

            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);
        }

        // POST: api/Filmes
        [HttpPost]
        public async Task<IActionResult> PostFilme(FilmeViewModel filme)
        {
            var retornoFilme = await _filmeAppService.Adicionar(filme);

            if (!retornoFilme.ValidationResult.IsValid)
            {
                foreach (var item in retornoFilme.ValidationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }

                return Conflict(ModelState.Values.Select(x => x.Errors));
            }

            return CreatedAtAction("GetFilme", new { id = retornoFilme.IdFilme }, retornoFilme);
        }

        // PUT api/Filmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, FilmeViewModel filme)
        {
            if (id != filme.IdFilme)
            {
                return NotFound();
            }

            var retornoFilme = await _filmeAppService.Atualizar(filme);

            if (!retornoFilme.ValidationResult.IsValid)
            {
                foreach (var item in retornoFilme.ValidationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }

                return Conflict(ModelState.Values);
            }

            return CreatedAtAction("GetFilme", new { id = retornoFilme.IdFilme }, retornoFilme);
        }

        // DELETE api/Filmes/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
