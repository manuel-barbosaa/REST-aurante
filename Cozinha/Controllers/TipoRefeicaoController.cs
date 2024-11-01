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



      // GET: api/TipoRefeicao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListarTipoRefeicaoDTO>> GetTiposRefeicaoById(long id)
        {
            var tipo = await _service.GetTipoRefeicaoById(id);
            return tipo == null ? NotFound() : Ok(tipo);
        }

        // POST: api/TipoRefeicao
        [HttpPost]
        public async Task<ActionResult<ListarTipoRefeicaoDTO>> PostTipoRefeicao(DefinirTipoRefeicaoDTO tr)
        {
            return await _service.AddTipoRefeicao(tr);
        }
        // PUT: api/TipoRefeicao/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ListarTipoRefeicaoDTO>> PutTipoRefeicao(long id, DefinirTipoRefeicaoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoRefeicaoAtualizado = await _service.UpdateTipoRefeicao(id, dto);
            return tipoRefeicaoAtualizado == null ? NotFound() : Ok(tipoRefeicaoAtualizado);
        }
    }



    }

    



