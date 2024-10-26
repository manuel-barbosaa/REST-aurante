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

        // GET: api/Ingrediente
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

    

        // // PUT: api/Ingrediente/5
        // [HttpPut("{id}")]
        // public async Task<ActionResult<Ingrediente2detail_dto>> PutIngrediente(long id, Ingrediente2update_dto info)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }

        //     var updatedIngrediente = await _service.PutIngrediente(id, info);

        //     return (updatedIngrediente == null) ? NotFound() : updatedIngrediente;
        // }

       

        
    }
}