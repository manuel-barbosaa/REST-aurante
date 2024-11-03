using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Cozinha.Services {
    public class PratoService {

        //contexto de banco de dados e repositorio para acessar os dados do prato e ingredientes
        private CozinhaContext _context;
        private PratoRepository _repo;

        //construtor do serviço, inicializa o contexto e o repositório
        public PratoService(CozinhaContext context) {
            _context = context;
            _repo = new PratoRepository(_context);
        }

        //método que retorna uma lista de todos os pratos convetidos para DTO
        public async Task<List<ListarPratoDTO>> GetPratos() {
            List<Prato> Pratos = await _repo.GetPrato();

            return Pratos.Select(x => PratoListItem(x)).ToList();
        }

        //Retorna um prato específico pelo seu id; lança uma exceção se o prato não for encontrado
        public async Task<ListarPratoDTO> GetPrato(long id) {
            Prato ?p = await _repo.GetPratoById(id);
            if (p == null)
            {
                throw new Exception("Prato not found");
            }
            return PratoDetail(p);
        }

        //Retorna uma lista de pratos ativos convertidos para DTO
        public async Task<List<ListarPratoDTO>> GetPratosAtivosList()
        {
            List<Prato> allActivePratos = await _repo.GetPratosByState(true);
        
            return allActivePratos.Select(x => PratoListItem(x)).ToList();
        }

        //cria um novo prato com os dados recebidos em CriarPratoDTO e salva no banco de dados


        public async Task<ListarPratoDTO> CreateNewPrato(CriarPratoDTO info)
        {
            if (info.TipoPratoId <= 0)
            {
                throw new Exception("TipoPratoId must be provided and greater than 0.");
            }

            // Verifica se o TipoPrato existe
            TipoPrato? tipoPrato = await _context.TiposPrato.FindAsync(info.TipoPratoId);
            if (tipoPrato == null)
            {
                throw new Exception("TipoPrato not found");
            }

            List<Ingrediente> ingredientesToSave = new List<Ingrediente>();

            // Verifica se os ingredientes existem
            if (info.Ingredientes.Any())
            {
                foreach (var existingId in info.Ingredientes)
                {
                    var existingIngredient = await _context.Ingredientes.FindAsync(existingId);
                    if (existingIngredient != null)
                    {
                        ingredientesToSave.Add(existingIngredient);
                    }
                    else
                    {
                        throw new Exception($"Ingrediente with Id {existingId} not found");
                    }
                }
            }
            else
            {
                throw new Exception("ExistingIngredientIds must be provided");
            }

            // Cria o prato incluindo a receita
            Prato newPrato = new Prato
            {
                Nome = info.Nome,
                IsAtivo = info.IsAtivo,
                TipoPrato = tipoPrato,
                Ingredientes = ingredientesToSave,
                // Receita = info.Receita // Adiciona a receita ao prato
            };

            return PratoDetail(await _repo.AddPrato(newPrato));
        }


        //converte um objeto Prato em ListarPratoDTO para retornar apenas informações resumidas
        private ListarPratoDTO PratoListItem(Prato p) {
            return new ListarPratoDTO {
                Id = p.Id,
                Nome = p.Nome,
                IsAtivo = p.IsAtivo,
                TipoPrato = p.TipoPrato,
                Ingredientes = p.Ingredientes,
                // Receita = p.Receita
            };
        }

        //converte um objeto Prato em ListarPratoDTO para retornar informações detalhadas
        private ListarPratoDTO PratoDetail(Prato p)
        {
            return new ListarPratoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                IsAtivo = p.IsAtivo,
                TipoPrato = p.TipoPrato,
                Ingredientes = p.Ingredientes,
                // Receita = p.Receita
            };
        }

        //US008- Ativação e inativação de um Prato pelo ID; Lança uma exceção se o prato não for encontrado
        public async Task<ListarPratoDTO> AtivarPrato(long id)
        {
            var prato = await _repo.GetPratoById(id);
            if (prato == null) throw new Exception("Prato not found");

            prato.IsAtivo = true;
            return PratoDetail(await _repo.UpdatePrato(prato));
        }

        public async Task<ListarPratoDTO> InativarPrato(long id)
        {
            var prato = await _repo.GetPratoById(id);
            if (prato == null) throw new Exception("Prato not found");

            prato.IsAtivo = false;
            return PratoDetail(await _repo.UpdatePrato(prato));
        }

        // US009- Inativação de um Ingrediente pelo nome e inativa os pratos que o contêm
        public async Task InativarIngrediente(string nomeIngrediente)
        {
            var ingrediente = await _context.Ingredientes.
            FirstOrDefaultAsync(i => i.Nome.Equals(nomeIngrediente));

            if (ingrediente == null) throw new Exception("Ingrediente not found");

            await _repo.InativarIngrediente(ingrediente);
}

        // US010- Ativação de um Ingrediente pelo nome e reativa pratos que dependem apenas de ingredientes ativos
        public async Task AtivarIngrediente(string nomeIngrediente)
        {
            var ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(i => i.Nome.Equals(nomeIngrediente));

            if (ingrediente == null) throw new Exception("Ingrediente not found");

            await _repo.AtivarIngrediente(ingrediente); //chama o método do repositório para ativar o ingrediente
        }
        
        public async Task<bool> DeletePrato(long id)
        {
            // Busca o prato pelo ID
            var prato = await _context.Pratos.FindAsync(id);

            // Verifica se o prato existe
            if (prato == null)
            {
                return false; // Retorna false se o prato não for encontrado
            }

            // Remove o prato do contexto
            _context.Pratos.Remove(prato);

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return true; // Retorna true indicando que o prato foi removido
        }




    }
}