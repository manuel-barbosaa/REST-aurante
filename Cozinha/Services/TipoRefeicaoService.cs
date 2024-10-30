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

public async Task<ListarTipoRefeicaoDTO> DefinirTipoRefeicao(long id, DefinirTipoRefeicaoDTO dto)
{
    // Localizar o TipoRefeicao pelo ID fornecido
    var tipoRefeicao = await _context.TipoRefeicao.FindAsync(id);

    // Verificar se o tipo de refeição existe no banco de dados
    if (tipoRefeicao == null)
    {
        throw new KeyNotFoundException("Tipo de Refeição não encontrado.");
    }

    // Atualizar os campos com os valores do DTO
    tipoRefeicao.Nome = dto.Nome;
    tipoRefeicao.Descricao = dto.Descricao;

    // Salvar as alterações no banco de dados
    await _context.SaveChangesAsync();

    // Retornar o tipo de refeição atualizado como DTO
    return TipoRefeicaoListItem(tipoRefeicao);
}


// Método para obter um tipo de refeição específico pelo ID
        public async Task<ListarTipoRefeicaoDTO> GetTipoRefeicaoById(long id)
        {
            var tipo = await _repo.GetTipoRefeicaoById(id);
            return tipo == null ? null : new ListarTipoRefeicaoDTO
            {
                Id = tipo.Id,
                Nome = tipo.Nome,
               
            };
        }

        // Método para criar um novo tipo de refeição
        public async Task<ListarTipoRefeicaoDTO> AddTipoRefeicao(DefinirTipoRefeicaoDTO dto)
        {
            var novoTipoRefeicao = new TipoRefeicao
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            await _repo.AddTipoRefeicao(novoTipoRefeicao);

            return new ListarTipoRefeicaoDTO
            {
                Id = novoTipoRefeicao.Id,
                Nome = novoTipoRefeicao.Nome,
             
            };
        }

        // Método para atualizar um tipo de refeição
        public async Task<ListarTipoRefeicaoDTO> UpdateTipoRefeicao(long id, DefinirTipoRefeicaoDTO dto)
        {
            var tipoRefeicao = await _repo.GetTiposRefeicaoById(id);
            if (tipoRefeicao == null) return null;

            tipoRefeicao.Nome = dto.Nome;
            tipoRefeicao.Descricao = dto.Descricao;

            await _repo.UpdateTipoRefeicao(tipoRefeicao);

            return new ListarTipoRefeicaoDTO
            {
                Id = tipoRefeicao.Id,
                Nome = tipoRefeicao.Nome,
              
            };
        }
    }
    }
    
    
