using Microsoft.AspNetCore.Mvc;
using Cozinha.Model;
using Cozinha.Model.DTO;
using Cozinha.Services;

namespace Cozinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRefeicaoController : ControllerBase
    {
       
        private readonly CozinhaContext _context;
       private TipoRefeicaoService _service;

        public TipoRefeicaoController (CozinhaContext context) {
            _context = context;
            _service = new TipoRefeicaoService(_context);
        }


            // GET: api/TiposRefeicao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListarTipoRefeicaoDTO>>> GetTiposRefeicao()
        {
            return await _service.GetTiposRefeicao();
        }
    }
}
