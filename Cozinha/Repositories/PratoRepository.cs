using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories{
    public class PratoRepository {
        private CozinhaContext _context;

        public PratoRepository(CozinhaContext context) {
            _context = context;
        }

        public async Task<List<Prato>> GetPrato() {
            return await _context.Pratos.ToListAsync();
        }

        public async Task<Prato?> GetPratoById(long id) {
            return await _context.Pratos.FindAsync(id);
        }

        public async Task<Prato?> GetPratoByNome(string nome) {
            return await _context.Pratos.FirstOrDefaultAsync(tp => tp.Nome.Equals(nome));
        }

        public async Task<List<Prato>> GetPratoByTipoPrato(TipoPrato tipoPrato) {
            return await _context.Pratos.Where(p => p.TipoPrato.Equals(tipoPrato)).ToListAsync();
        }

        public async Task<List<Prato>> GetPratoByIngrediente(Ingrediente ingrediente) {
            return await _context.Pratos.Where(p => p.Ingredientes.Contains(ingrediente)).ToListAsync();
        }

        public async Task<List<Prato>> GetPratoByIngredienteNome(string nome) {
            return await _context.Pratos.Where(p => p.Ingredientes.Any(i => i.Nome.Equals(nome))).ToListAsync();
        }
    } 
}