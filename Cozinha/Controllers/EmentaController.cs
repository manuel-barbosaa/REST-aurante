using Microsoft.AspNetCore.Mvc;
using Cozinha.Model;
using Cozinha.Model.DTO;
using Cozinha.Services;

namespace Cozinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmentaController : ControllerBase
    {
       
        private readonly CozinhaContext _context;
       private EmentaService _service;

        public EmentaController (CozinhaContext context) {
            _context = context;
            _service = new EmentaService(_context);
        }
        // GET: api/Ementa/Disponivel?tipo=Diaria&dataInicio=2024-10-30&dataFim=2024-10-30
        [HttpGet("Disponivel")]
        public async Task<ActionResult<ListarEmentaDTO>> GetEmentaDisponivel([FromQuery] string tipo, [FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
        {
            var ementa = await _service.GetEmentaDisponivel(tipo, dataInicio, dataFim);
            return ementa == null ? NotFound() : Ok(ementa);
        }

        // POST: api/Ementa
        [HttpPost]
        public async Task<IActionResult> AddEmenta([FromBody] Ementa ementa)
        {
            await _service.AddEmenta(ementa);
            return CreatedAtAction(nameof(GetEmentaDisponivel), new { tipo = ementa.Frequencia, dataInicio = ementa.DataInicio, dataFim = ementa.DataFim }, ementa);
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
