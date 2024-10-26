using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories
{
    public class IngredienteRepository
    {
        private CozinhaContext _context;
        public IngredienteRepository(CozinhaContext context)
        {
            _context = context;
        }

        public async Task<List<Ingrediente>> GetAllIngredientesFromDataBase()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        public async Task<List<Ingrediente>> GetIngredientesByStateFromDataBase(bool state)
        {
            return await _context.Ingredientes.Where(i => i.Ativo == state).ToListAsync();
        }

        /*
                public async Task<Ingrediente?> GetIngredienteById(long id)
                {
                    return await _context.Ingredientes.Include(p => p.Produto).FirstOrDefaultAsync(i => i.Id == id);
                }

                public async Task<Ingrediente?> GetIngredienteByName(string name)
                {
                    return await _context.Ingredientes.Include(p => p.Produto).FirstOrDefaultAsync(i => i.Name.Equals(name));
                }
        */

        public async Task<Ingrediente> UpdateIngrediente(Ingrediente ingrediente)
        {
            _context.Entry(ingrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return ingrediente;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<Ingrediente> AddIngrediente(Ingrediente ingrediente)
        {
            var newIngrediente = await _context.Ingredientes.AddAsync(ingrediente);

            await _context.SaveChangesAsync();
            return newIngrediente.Entity;
        }

        public async Task<bool> Remove(Ingrediente ingrediente)
        {
            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}