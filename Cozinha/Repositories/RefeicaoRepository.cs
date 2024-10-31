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
        public async Task<List<Refeicao>> GetRefeicao() {
            return await _context.Refeicao.ToListAsync();
        }
        //obtem uma refeição pelo seu id
        public async Task<Refeicao?> GetRefeicaoById(long id) {
            return await _context.Refeicao.FindAsync(id);
        }
        //obtem Refeicao pelo tipo de refeicao 
        public async Task<List<Refeicao>> GetRefeicaoByTipoRefeicao(TipoRefeicao tipoRefeicao) {
            return await _context.Refeicao.Where(p => p.TipoRefeicao.Equals(tipoRefeicao)).ToListAsync();
        }
        //Apagar uma refeicao
        public async Task DeleteRefeicao(long id) {
            var refeicao = await _context.Refeicao.FindAsync(id);
            if (refeicao != null) {
                _context.Refeicao.Remove(refeicao);
                await _context.SaveChangesAsync();
            }
        }
    }  


}