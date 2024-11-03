using Microsoft.AspNetCore.Mvc;
using Cozinha.Model.DTO;
using Cozinha.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cozinha.Model;

namespace Cozinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmentaController : ControllerBase
    {
        private readonly CozinhaContext _context;
        private EmentaService _service;

        public EmentaController(CozinhaContext context)
        {
            _context = context;
            _service = new EmentaService(context);
        }

        // GET: api/Ementa/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ListarEmentaDTO>>> GetEmentas()
        {
            return await _service.GetEmentas();
        }

         // GET /api/Ementa/1
        [HttpGet("{id}")]  
        public async Task<ActionResult<ListarEmentaDTO>> GetEmentaById(long id)
        {
            return await _service.GetEmentaById(id);
        }

        // POST: api/Ementa
        [HttpPost]
        public async Task<ActionResult<ListarEmentaDTO>> PostPrato(CriarEmentaDTO ementa)
        {
            return await _service.CreateNewEmenta(ementa);
        }

    }
}
