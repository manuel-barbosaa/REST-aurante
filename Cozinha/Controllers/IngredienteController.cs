using Microsoft.AspNetCore.Mvc;
using Cozinha.Model.DTO;
using Cozinha.Services;

namespace Cozinha.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredienteController : ControllerBase
{
    private readonly IngredienteService _service;

    public IngredienteController(IngredienteService service)
    {
        _service = service;
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
        return await _service.GetIngredientesInativosList();
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
}