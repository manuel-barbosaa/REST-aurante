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


        // GET: api/TiposPrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListarTipoPratoDTO>>> GetTiposPrato()
        {
            return await _service.GetTiposPrato();
        }

        // GET: api/Heroes/1
        // GET: api/Heroes/vegetariano
        [HttpGet("{value}")]
        public async Task<ActionResult<DetalharTipoPratoDTO>> GetHeroByValue(string value)
        {
            var tipoPrato = await _service.GetTipoPratoByValor(value);

            return (tipoPrato == null)? NotFound() : tipoPrato;
        }
    }
}