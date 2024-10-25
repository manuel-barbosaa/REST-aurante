using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories{
    public class TipoPratoRepository {
        private CozinhaContext _context;

        public TipoPratoRepository(CozinhaContext context) {
            _context = context;
        }

        public async Task<List<TipoPrato>> GetTiposPrato() {
            return await _context.TiposPrato.ToListAsync();
        }

        public async Task<TipoPrato?> GetTipoPratoById(long id) {
            return await _context.TiposPrato.FindAsync(id);
        }

        public async Task<TipoPrato?> GetTipoPratoByNome(string nome) {
            return await _context.TiposPrato.FirstOrDefaultAsync(tp => tp.Nome.Equals(nome));
        }
    } 
}