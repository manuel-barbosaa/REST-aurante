using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;



namespace Cozinha.Services{
    public class EmentaService{
         private CozinhaContext _context;
        private EmentaRepository _repo;

        public EmentaService(CozinhaContext context) {
            _context = context;
            _repo = new EmentaRepository(_context);
        }

        // Método para buscar e converter uma ementa com suas refeições para DTO
        public async Task<ListarEmentaDTO?> GetEmentaDisponivel(string tipo, DateTime dataInicio, DateTime dataFim)
        {
            var ementa = await _repo.GetEmentaByTipoEData(tipo, dataInicio, dataFim);

            if (ementa == null) return null;

            return new ListarEmentaDTO
            {
                Tipo = ementa.Frequencia,
                Refeicoes = ementa.Refeicoes.Select(r => new ListarRefeicaoDTO
                {
                    Id = r.Id,
                    Prato = r.Prato,
                    TipoRefeicao = r.TipoRefeicao,
                    Quantidade = r.Quantidade,
                    Data = r.Data
                }).ToList()
            };
        }

        // Método para adicionar uma nova ementa
        public async Task AddEmenta(Ementa ementa)
        {
            await _repo.AddEmenta(ementa);
        }



         public async Task<bool> DeleteEmenta(long id)
        {
            var ementa = await _repo.GetEmentaById(id);
            if (ementa == null)
            {
                return false;
            }

            await _repo.RemoveEmenta(ementa);

            return true;
        }
    }
}

        