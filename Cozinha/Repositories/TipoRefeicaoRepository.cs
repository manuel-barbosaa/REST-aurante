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


         public async Task<TipoRefeicao> GetTiposRefeicaoById(long Id)
        {
            return await _context.TipoRefeicao.FindAsync(Id);
        }

        public async Task AddTipoRefeicao(TipoRefeicao tipoRefeicao)
        {
            _context.TipoRefeicao.Add(tipoRefeicao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTipoRefeicao(TipoRefeicao tipoRefeicao)
        {
            _context.Entry(tipoRefeicao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    } 
    
