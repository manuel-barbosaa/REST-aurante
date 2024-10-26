// using Cozinha.Model.DTO;
// using Cozinha.Model;
// using Cozinha.Repositories;

// namespace Cozinha.Services {
//     public class PratoService {

//         private CozinhaContext _context;
//         private PratoRepository _repo;

//         public PratoService(CozinhaContext context) {
//             _context = context;
//             _repo = new PratoRepository(_context);
//         }

//         public async Task<List<ListarPratoDTO>> GetPratos() {
//             List<Prato> Pratos = await _repo.GetPrato();

//             return Pratos.Select(x => PratoListItem(x)).ToList();
//         }

//         public async Task<DetalharPratoDTO?> GetPratoByValor(string value)
//         {
//             Prato? Prato;

//             if (long.TryParse(value, out long id))
//                 Prato = await _repo.GetPratoById(id);
//             else
//                 Prato = await _repo.GetPratoByNome(value);

//             if (Prato == null)
//             {
//                 return null;
//             }

//             return DetalharPrato(Prato);
//         }

//         private ListarPratoDTO PratoListItem(Prato tp) {
//             return new ListarPratoDTO {
//                 Id = tp.Id,
//                 Nome = tp.Nome
//             };
//         }

//         private DetalharPratoDTO DetalharPrato (Prato tp) {
//             return new DetalharPratoDTO {
//                 Nome = tp.Nome
//             };
//         }
//     }
// }