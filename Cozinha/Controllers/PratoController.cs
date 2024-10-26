// using Microsoft.AspNetCore.Mvc;
// using Cozinha.Model;
// using Cozinha.Services;
// using Cozinha.Model.DTO;

// namespace Cozinha.Controllers {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class PratoController : ControllerBase {
//         private readonly CozinhaContext _context;
//         private PratoService _service;

//         public PratoController (CozinhaContext context) {
//             _context = context;
//             _service = new PratoService(_context);
//         }


//         // GET: api/TiposPrato
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<ListarPratoDTO>>> GetTiposPrato()
//         {
//             return await _service.GetPrato();
//         }

//         // GET: api/Heroes/1
//         // GET: api/Heroes/vegetariano 
//         [HttpGet("{value}")]
//         public async Task<ActionResult<DetalharPratoDTO>> GetHeroByValue(string value)
//         {
//             var Prato = await _service.GetPratoByValor(value);

//             return (Prato == null)? NotFound() : Prato;
//         }
//     }
// }