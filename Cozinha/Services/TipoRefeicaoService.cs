using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;



namespace Cozinha.Services{
    public class TipoRefeicaoService{
         private CozinhaContext _context;
        private TipoRefeicaoRepository _repo;

        public TipoRefeicaoService(CozinhaContext context) {
            _context = context;
            _repo = new TipoRefeicaoRepository(_context);
        }
    public async Task<List<ListarTipoRefeicaoDTO>> GetTiposRefeicao() {
            List<TipoRefeicao> TiposRefeicao = await _repo.GetTiposRefeicao();

            return TiposRefeicao.Select(x => TipoRefeicaoListItem(x)).ToList();
        }

 private ListarTipoRefeicaoDTO TipoRefeicaoListItem(TipoRefeicao tp) {
            return new ListarTipoRefeicaoDTO {
                Id = tp.Id,
                Nome = tp.Nome

            };
        }


    }
}