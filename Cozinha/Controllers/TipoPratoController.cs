using Microsoft.AspNetCore.Mvc;
using Cozinha.Model;
using Cozinha.Services;
using Cozinha.Model.DTO;

namespace Cozinha.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPratoController : ControllerBase {
        private readonly CozinhaContext _context;
        private TipoPratoService _service;

        public TipoPratoController (CozinhaContext context) {
            _context = context;
            _service = new TipoPratoService(_context);
        }


        // GET: api/TipoPrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPratoDTO>>> GetTiposPrato()
        {
            return await _service.GetTiposPrato();
        }

        // GET: api/TipoPrato/1
        // GET: api/TipoPrato/vegetariano
        [HttpGet("{value}")]
        public async Task<ActionResult<TipoPratoDTO>> GetTipoPratoByValue(string value)
        {
            var tipoPrato = await _service.GetTipoPratoByValor(value);

            return (tipoPrato == null)? NotFound() : tipoPrato;
        }

        // POST: api/TipoPrato
        [HttpPost]
        public async Task<ActionResult<TipoPratoDTO>> PostTipoPrato(TipoPrato tp)
        {
            return await _service.CreateNewTipoPrato(tp);
        }

        // DELETE: api/TipoPrato/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPrato(long id)
        {
            bool deleteAction = await _service.DeleteTipoPrato(id);

            return deleteAction? Ok() : NotFound();
        }
    }
}