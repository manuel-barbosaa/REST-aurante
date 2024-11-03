using Microsoft.AspNetCore.Mvc;
using Cozinha.Model.DTO;
using Cozinha.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cozinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmentaController : ControllerBase
    {
        private readonly EmentaService _service;

        // Injeção de dependência para o EmentaService
        public EmentaController(EmentaService service)
        {
            _service = service;
        }

        // // GET: api/Ementa/Disponivel?tipoRefeicaoId=1&data=2024-10-01
        // [HttpGet("Disponivel")]
        // public async Task<ActionResult<IEnumerable<ListarEmentaDTO>>> GetEmentaDisponivel([FromQuery] long tipoRefeicaoId, [FromQuery] DateTime data)
        // {
        //     var ementas = await _service.GetEmentaDisponivel(tipoRefeicaoId, data);
        //     return Ok(ementas);
        // }
       
        // POST: api/Ementa
        [HttpPost]
        public async Task<ActionResult<ListarEmentaDTO>> AddEmenta([FromBody] CriarEmentaDTO ementaInfo)
        {
            var novaEmenta = await _service.AddEmenta(ementaInfo);
            return CreatedAtAction(nameof(GetEmentaDisponivelById), new { id = novaEmenta.Id }, novaEmenta);
        }

        // GET: api/Ementa/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListarEmentaDTO>> GetEmentaDisponivelById(long id)
        {
            var ementa = await _service.GetEmentaDisponivelById(id);
            return ementa == null ? NotFound() : Ok(ementa);
        }

         // DELETE: api/Prato/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmenta(long id)
        {
            var deleted = await _service.DeleteEmenta(id);

            if (!deleted)
            {
                return NotFound(); // Retorna 404 se o prato não for encontrado
            }

            return NoContent(); // Retorna 204 se o prato for removido com sucesso
        }

    }
}
