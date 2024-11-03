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
        public async Task<ListarEmentaDTO> CreateNewEmenta(CriarEmentaDTO info)
        {
            List<Refeicao> refeicoes = new List<Refeicao>();

            // Verifica se os ingredientes existem
            if (info.Refeicoes.Any())
            {
                foreach (var existingId in info.Refeicoes)
                {
                    var existingRefeicao = await _context.Refeicao.FindAsync(existingId);
                    if (existingRefeicao != null)
                    {
                        refeicoes.Add(existingRefeicao);
                    }
                    else
                    {
                        throw new Exception($"Refeicao with Id {existingId} not found");
                    }
                }
            }
            else
            {
                throw new Exception("ExistingRefeicoesIds must be provided");
            }

            // Cria o prato incluindo a receita
            Ementa newEmenta = new Ementa
            {
                Frequencia = info.Frequencia,
                DataInicio = info.DataInicio,
                DataFim = info.DataFim,
                Refeicoes = refeicoes
            };

            return EmentaDetail(await _repo.AddEmenta(newEmenta));
        }

        private ListarEmentaDTO EmentaDetail(Ementa e)
        {
            return new ListarEmentaDTO
            {
                Id = e.Id,
                Frequencia = e.Frequencia,
                DataInicio = e.DataInicio,
                DataFim = e.DataFim,
                Refeicoes = e.Refeicoes
            };
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

        