using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozinha.Model;
using Cozinha.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cozinha.Services;


namespace Cozinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        private readonly CozinhaContext _context;
        private PratoService _service;

        public PratoController(CozinhaContext context)
        {
            _context = context;
            _service = new PratoService(context);
        }

        // GET: api/Prato
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ListarPratoDTO>>> GetPratos()
        {
            return await _service.GetPratos();
        }

        // GET: api/Prato/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<ListarPratoDTO>>> GetAvailablePratos()
        {
            return await _service.GetPratosAtivosList();
        }

         // GET /api/Prato/1
        [HttpGet("{id}")]  
        public async Task<ActionResult<ListarPratoDTO>> GetPrato(long id)
        {
            return await _service.GetPrato(id);
        }

        // POST: api/Prato
        [HttpPost]
        public async Task<ActionResult<ListarPratoDTO>> PostPrato(CriarPratoDTO prato)
        {
            return await _service.CreateNewPrato(prato);
        }

        // PUT: api/Prato/5
        // [HttpPut("{id}")]
        // public async Task<ActionResult<ListarPratoDTO>> PutPrato(long id, Prato prato)
        // {
        //     if (id != prato.Id)
        //     {
        //         return BadRequest();
        //     }

        //     try
        //     {
        //         return await _service.UpdatePrato(prato);
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         throw;
        //     }
        // }
        
    }
}