using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;

namespace Cozinha.Services {
    public class TipoPratoService {

        private CozinhaContext _context;
        private TipoPratoRepository _repo;

        public TipoPratoService(CozinhaContext context) {
            _context = context;
            _repo = new TipoPratoRepository(_context);
        }

        public async Task<List<ListarTipoPratoDTO>> GetTiposPrato() {
            List<TipoPrato> TiposPrato = await _repo.GetTiposPrato();

            return TiposPrato.Select(x => TipoPratoListItem(x)).ToList();
        }

        public async Task<DetalharTipoPratoDTO?> GetTipoPratoByValor(string value)
        {
            TipoPrato? tipoPrato;

            if (long.TryParse(value, out long id))
                tipoPrato = await _repo.GetTipoPratoById(id);
            else
                tipoPrato = await _repo.GetTipoPratoByNome(value);

            if (tipoPrato == null)
            {
                return null;
            }

            return DetalharTipoPrato(tipoPrato);
        }

        private ListarTipoPratoDTO TipoPratoListItem(TipoPrato tp) {
            return new ListarTipoPratoDTO {
                Id = tp.Id,
                Nome = tp.Nome
            };
        }

        private DetalharTipoPratoDTO DetalharTipoPrato (TipoPrato tp) {
            return new DetalharTipoPratoDTO {
                Nome = tp.Nome
            };
        }
    }
}