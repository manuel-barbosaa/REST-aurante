using Microsoft.AspNetCore.Mvc;
using Cozinha.Model.DTO;
using Cozinha.Services;
using Cozinha.Model;

namespace Cozinha.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredienteController : ControllerBase
{
    private readonly CozinhaContext _context;
    private readonly IngredienteService _service; 
        
    public IngredienteController(CozinhaContext context)
    {
        _context = context;
        _service = new IngredienteService(_context);
    }

    // GET: api/Ingrediente/all
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetIngredientes()
    {
        return await _service.GetIngredientesList();
    }

    // GET: api/Ingrediente/available
    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetAvailableIngredientes()
    {
        var ingredientes = await _service.GetIngredientesAtivosList();
        if (ingredientes == null || !ingredientes.Any())
        {
            return NotFound(new { message = "Não há ingredientes disponíveis no momento." });
        }
        return Ok(ingredientes);
    }

// GET: api/Ingrediente/unavailable
    [HttpGet("unavailable")]
    public async Task<ActionResult<IEnumerable<ListarIngredienteDTO>>> GetUnavailableIngredientes()
    {
        var ingredientes = await _service.GetIngredientesInativosList();
        if (ingredientes == null || !ingredientes.Any())
        {
            return NotFound(new { message = "Não há ingredientes indisponíveis no momento." });
        }
        return Ok(ingredientes);
    }


    // GET: api/Ingrediente/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ListarIngredienteDTO>> GetIngredienteById(long id) 
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
        return CreatedAtAction(nameof(GetIngredienteById), new { id = createdIngrediente.Id }, createdIngrediente); 
    }

    // DELETE: api/Ingrediente/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredienteById(long id)
    {
        bool deleted = await _service.DeleteIngredienteById(id);
        if (!deleted)
        {
            return NotFound();
        }
        return Ok(new { message = $"Ingrediente com ID {id} foi eliminado com sucesso." });
    }


    // DELETE: api/Ingrediente/all
    [HttpDelete("all")]
    public async Task<IActionResult> DeleteAllIngredientes()
    {
        await _service.DeleteAllIngredientes();
        return Ok(new { message = "Todos os ingredientes foram eliminados com sucesso." });
    }


    // PUT: api/Ingrediente/{id}/available
    [HttpPut("{id}/available")]
    public async Task<IActionResult> SetIngredienteAvailable(long id)
    {
        var updated = await _service.UpdateIngredienteStatus(id, true);
        if (updated == null)
        {
            return NotFound();
        }
        return Ok(updated);
    }

    // PUT: api/Ingrediente/{id}/unavailable
    [HttpPut("{id}/unavailable")]
    public async Task<IActionResult> SetIngredienteUnavailable(long id)
    {
        var updated = await _service.UpdateIngredienteStatus(id, false);
        if (updated == null)
        {
            return NotFound();
        }
        return Ok(updated);
    }
}
