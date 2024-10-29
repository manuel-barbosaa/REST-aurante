using Microsoft.EntityFrameworkCore;
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

        public async Task<ListarIngredienteDTO> CreateNewIngrediente(CriarIngredienteDTO info)
        {
            Ingrediente newIngrediente = new Ingrediente
            {
                Nome = info.Nome,
                CategoriaAlimenticia = info.CategoriaAlimenticia,
                Ativo = info.Ativo
            };
            return IngredienteDetail(await _repo.AddIngrediente(newIngrediente));
        }
        private ListarIngredienteDTO IngredienteListItem(Ingrediente i)
        {
            return new ListarIngredienteDTO
            {
                // Id = i.Id,
                Nome = i.Nome,
                // CategoriaAlimenticia = i.CategoriaAlimenticia,
                // Ativo = i.Ativo
            };
        }

        private ListarIngredienteDTO IngredienteDetail(Ingrediente i)
        {
            return new ListarIngredienteDTO
            {
                // Id = i.Id,
                Nome = i.Nome,
                CategoriaAlimenticia = i.CategoriaAlimenticia,
                Ativo = i.Ativo
            };
        }
    }