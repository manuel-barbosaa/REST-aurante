using Cozinha.Model;
using Cozinha.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories{
    public class RefeicaoRepository {
        //contexto de banco de dados para manipular as operações relacionadas ao modelo de prato
        private CozinhaContext _context;
        //construtor do repositório, inicializa o contexto
        public RefeicaoRepository(CozinhaContext context) {
            _context = context;
        }
        //adiciona uma nova refeição no banco de dados
        public async Task<Refeicao> AddRefeicao(Refeicao refeicao) {
            var newRefeicao = await _context.Refeicao.AddAsync(refeicao);

            await _context.SaveChangesAsync();
            return newRefeicao.Entity;
        }
        //obtem todas as refeições
        public async Task<List<Refeicao>> GetRefeicoes() {
            return await _context.Refeicao.Include(p => p.Prato).Include(tp => tp.Prato.TipoPrato).Include(i => i.Prato.Ingredientes).Include(p => p.TipoRefeicao).ToListAsync();
        }
        //obtem uma refeição pelo seu id
        public async Task<Refeicao?> GetRefeicaoById(long id) {
            return await _context.Refeicao.Include(p => p.Prato).Include(tp => tp.Prato.TipoPrato).Include(i => i.Prato.Ingredientes).Include(p => p.TipoRefeicao).FirstOrDefaultAsync(p => p.Id == id);;
        }
        //obtem Refeicao pelo tipo de refeicao 
        public async Task<List<Refeicao>> GetRefeicaoByTipoRefeicao(TipoRefeicao tipoRefeicao) {
            return await _context.Refeicao.Where(p => p.TipoRefeicao.Equals(tipoRefeicao)).ToListAsync();
        }
        // Remover uma refeição específica
        public async Task DeleteRefeicao(Refeicao refeicao)
        {
            _context.Refeicao.Remove(refeicao);
            await _context.SaveChangesAsync();
        }

        // Atualizar uma refeição existente
        public async Task<Refeicao> UpdateRefeicao(Refeicao refeicao)
        {
            _context.Refeicao.Update(refeicao);
            await _context.SaveChangesAsync();
            return refeicao;
        }
        //Delete all refeicoes
        public async Task DeleteAll()
        {
            _context.Refeicao.RemoveRange(_context.Refeicao);
            await _context.SaveChangesAsync();
        }
        
       

    }
}