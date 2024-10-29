using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories{
    public class TipoRefeicaoRepository {
        private CozinhaContext _context;

        public TipoRefeicaoRepository(CozinhaContext context) {
            _context = context;
        }

        public async Task<List<TipoRefeicao>> GetTiposRefeicao() {
            return await _context.TipoRefeicao.ToListAsync();
        }

        public async Task<TipoRefeicao?> GetTipoRefeicaoById(long id) {
            return await _context.TipoRefeicao.FindAsync(id);
        }

        public async Task<TipoRefeicao?> GetTipoRefeicaoByNome(string nome) {
            return await _context.TipoRefeicao.FirstOrDefaultAsync(tp => tp.Nome.Equals(nome));
        }
    } 
}