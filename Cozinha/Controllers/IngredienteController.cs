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
    public class IngredienteController : ControllerBase
    {
        private readonly CozinhaContext _context;
        private IngredienteService _service;

        public IngredienteController(CozinhaContext context)
        {
            _context = context;
            _service = new IngredienteService(context);
        }

        // GET: api/Ingrediente/
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetIngredientes()
        {
            return await _service.GetIngredientesList();

        }

        // GET: api/Ingrediente/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetAvailableIngredientes()
        {
            return await _service.GetIngredientesAtivosList();
        }

        // GET: api/Ingrediente/unavailable
        [HttpGet("unavailable")]
        public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetUnavailableIngredientes()
        {
            return await _service.GetIngredientesAtivosList();
        }

            // GET: api/Ingrediente/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ListarIngredienteDTO>> GetIngredienteById(int id) 
        {
            var ingrediente = await _service.GetIngredienteById(id);
            if (ingrediente == null)
            {
                return NotFound(); 
            }
            return ingrediente;
        }

        // POST: api/Ingrediente
        [HttpPost]
        public async Task<ActionResult<ListarIngredienteDTO>> CreateIngrediente(CriarIngredienteDTO info)
        {
            var createdIngrediente = await _service.CreateNewIngrediente(info);
            return CreatedAtAction(nameof(GetIngredienteById), new { id = createdIngrediente.Nome }, createdIngrediente); 
        }
    }
}

    

        
       

        
   