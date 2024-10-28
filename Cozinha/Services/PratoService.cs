using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;

namespace Cozinha.Services {
    public class PratoService {

        private CozinhaContext _context;
        private PratoRepository _repo;

        public PratoService(CozinhaContext context) {
            _context = context;
            _repo = new PratoRepository(_context);
        }

        public async Task<List<ListarPratoDTO>> GetPratos() {
            List<Prato> Pratos = await _repo.GetPrato();

            return Pratos.Select(x => PratoListItem(x)).ToList();
        }

        public async Task<ListarPratoDTO> GetPrato(long id) {
            Prato ?p = await _repo.GetPratoById(id);
            if (p == null)
            {
                throw new Exception("Prato not found");
            }
            return PratoDetail(p);
        }

        public async Task<List<ListarPratoDTO>> GetPratosAtivosList()
        {
            List<Prato> allActivePratos = await _repo.GetPratosByState(true);
        
            return allActivePratos.Select(x => PratoListItem(x)).ToList();
        }

        public async Task<ListarPratoDTO> CreateNewPrato(CriarPratoDTO info)
        {
            Prato newPrato = new Prato
            {
                Id = info.Id,
                Nome = info.Nome,
                IsAtivo = info.IsAtivo,
                TipoPrato = info.TipoPrato,
                Ingredientes = info.Ingredientes
            };
            return PratoDetail(await _repo.AddPrato(newPrato));
        }

        private ListarPratoDTO PratoListItem(Prato p) {
            return new ListarPratoDTO {
                Nome = p.Nome,
                IsAtivo = p.IsAtivo,
                TipoPrato = p.TipoPrato,
                Ingredientes = p.Ingredientes,
            };
        }

        private ListarPratoDTO PratoDetail(Prato p)
        {
            return new ListarPratoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                IsAtivo = p.IsAtivo,
                TipoPrato = p.TipoPrato,
                Ingredientes = p.Ingredientes
            };
        }
    }
}