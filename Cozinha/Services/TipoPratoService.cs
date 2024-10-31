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

        public async Task<List<TipoPratoDTO>> GetTiposPrato() {
            List<TipoPrato> TiposPrato = await _repo.GetTiposPrato();

            return TiposPrato.Select(x => TipoPratoItem(x)).ToList();
        }

        public async Task<TipoPratoDTO?> GetTipoPratoByValor(string value)
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

            return TipoPratoItem(tipoPrato);
        }

        public async Task<TipoPratoDTO> CreateNewTipoPrato(TipoPrato tp)
        {
            return TipoPratoItem(await _repo.AddTipoPrato(tp));
        }

        public async Task<bool> DeleteTipoPrato(long id)
        {
            var tp = await _repo.GetTipoPratoById(id);
            if (tp == null)
            {
                return false;
            }

            await _repo.RemoveTipoPrato(tp);

            return true;
        }

        private TipoPratoDTO TipoPratoItem(TipoPrato tp) {
            return new TipoPratoDTO {
                Id = tp.Id,
                Nome = tp.Nome
            };
        }

    }
}