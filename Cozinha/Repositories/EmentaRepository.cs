using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories
{
    public class EmentaRepository
    {
        private readonly CozinhaContext _context;

        public EmentaRepository(CozinhaContext context)
        {
            _context = context;
        }

       public async Task<List<Ementa>> GetEmentas()
        {
            return await _context.Ementas
                .Include(e => e.Refeicoes)
                    .ThenInclude(r => r.Prato) 
                .Include(e => e.Refeicoes) 
                    .ThenInclude(r => r.TipoRefeicao) 
                .ToListAsync();
        }

        public async Task<Ementa?> GetEmentaById(long id)
        {
            return await _context.Ementas
                .Include(e => e.Refeicoes)
                    .ThenInclude(r => r.Prato)
                .Include(e => e.Refeicoes)
                    .ThenInclude(r => r.TipoRefeicao) 
                .FirstOrDefaultAsync(e => e.Id == id); 
        }
        public async Task<Ementa> AddEmenta(Ementa ementa)
        {
            var newEmenta = await _context.Ementas.AddAsync(ementa);
            await _context.SaveChangesAsync();
            return newEmenta.Entity;
        }

        public async Task<bool> RemoveEmenta(Ementa ementa)
        {
            _context.Ementas.Remove(ementa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
