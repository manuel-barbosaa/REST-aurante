using Cozinha.Repositories;
using Cozinha.Model;
using Cozinha.Model.DTO;

namespace Cozinha.Services;

public class IngredienteService
{
    private CozinhaContext _context;
    private IngredienteRepository _repo;

    public IngredienteService(CozinhaContext context)
    {
        _context = context;
        _repo = new IngredienteRepository(_context);
    }

    public async Task<List<ListarIngredienteDTO>> GetIngredientesList()
    {
        List<Ingrediente> allIngredientes = await _repo.GetAllIngredientesFromDataBase();
        return allIngredientes.Select(x => IngredienteListItem(x)).ToList();
    }

    public async Task<List<ListarIngredienteDTO>> GetIngredientesAtivosList()
    {
        List<Ingrediente> allActiveIngredientes = await _repo.GetIngredientesByStateFromDataBase(true);
        return allActiveIngredientes.Select(x => IngredienteListItem(x)).ToList();
    }

    public async Task<List<ListarIngredienteDTO>> GetIngredientesInativosList()
    {
        List<Ingrediente> allInactiveIngredientes = await _repo.GetIngredientesByStateFromDataBase(false);
        return allInactiveIngredientes.Select(x => IngredienteListItem(x)).ToList();
    }

    public async Task<ListarIngredienteDTO?> GetIngredienteById(long id)
    {
        var ingrediente = await _repo.GetIngredienteById(id);
        if (ingrediente == null)
        {
            return null;
        }
        return IngredienteDetail(ingrediente);
    }

    public async Task<ListarIngredienteDTO> CreateNewIngrediente(CriarIngredienteDTO info)
    {
        Ingrediente newIngrediente = new Ingrediente
        {
            Nome = info.Nome,
            CategoriaAlimenticia = info.CategoriaAlimenticia,
            Ativo = info.Ativo
        };

        var ingrediente = await _repo.AddIngrediente(newIngrediente);
        return IngredienteDetail(ingrediente);
    }

    private ListarIngredienteDTO IngredienteListItem(Ingrediente i)
    {
        return new ListarIngredienteDTO
        {
            Id = i.Id,
            Nome = i.Nome,
            CategoriaAlimenticia = i.CategoriaAlimenticia,
            Ativo = i.Ativo
        };
    }

    private ListarIngredienteDTO IngredienteDetail(Ingrediente i)
    {
        return new ListarIngredienteDTO
        {
            Id = i.Id,
            Nome = i.Nome,
            CategoriaAlimenticia = i.CategoriaAlimenticia,
            Ativo = i.Ativo
        };
    }
    
    public async Task<bool> DeleteIngredienteById(long id)
    {
        var ingrediente = await _repo.GetIngredienteById(id);
        if (ingrediente == null)
        {
            return false;
        }
        return await _repo.Remove(ingrediente);
    }

    public async Task DeleteAllIngredientes()
    {
        await _repo.RemoveAll();
    }
}
