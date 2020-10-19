using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Ioasys.Application.ViewModels;
using Desafio.Ioasys.Application.Interfaces.AppService;
using System.Linq;

namespace Desafio.Ioasys.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        private readonly IVotoAppService _votoAppService;

        public VotosController(IVotoAppService votoAppService)
        {
            _votoAppService = votoAppService;
        }

        // GET: api/Votos
        [HttpGet]
        public async Task<IActionResult> GetVotos()
        {
            var votos = await _votoAppService.ObterTodos();
            return Ok(votos);
        }

        // GET: api/Votos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoto(Guid id)
        {
            var voto = await _votoAppService.ObterPorId(id);

            if (voto == null)
            {
                return NotFound();
            }

            return Ok(voto);
        }

        // POST: api/Votos
        [HttpPost]
        public async Task<IActionResult> PostVoto(VotoViewModel voto)
        {
            var retornoVoto = await _votoAppService.Adicionar(voto);

            if (!retornoVoto.ValidationResult.IsValid)
            {
                foreach (var item in retornoVoto.ValidationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }

                return Conflict(ModelState.Values.Select(x => x.Errors));
            }

            return CreatedAtAction("GetVoto", new { id = retornoVoto.IdVoto }, retornoVoto);
        }

        // PUT api/Votos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoto(Guid id, VotoViewModel voto)
        {
            if (id != voto.IdVoto)
            {
                return NotFound();
            }

            var retornoVoto = await _votoAppService.Atualizar(voto);

            if (!retornoVoto.ValidationResult.IsValid)
            {
                foreach (var item in retornoVoto.ValidationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }

                return Conflict(ModelState.Values);
            }

            return CreatedAtAction("GetVoto", new { id = retornoVoto.IdVoto }, retornoVoto);
        }

        // DELETE api/Votos/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
