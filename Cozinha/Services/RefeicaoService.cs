using Cozinha.Model;
using Cozinha.Model.DTO;
using Cozinha.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Services {
    public class RefeicaoService {

        private  CozinhaContext _context;
        private  RefeicaoRepository _repo;

        public RefeicaoService(CozinhaContext context) {
            _context = context;
            _repo = new RefeicaoRepository(_context);
        }
        public async Task<ListarRefeicaoDTO> AddRefeicao(CriarRefeicaoDTO info)
        {
            // Verifica se o TipoPrato existe
            Prato? prato = await _context.Pratos.FindAsync(info.Prato);
            if (prato == null)
            {
                throw new Exception("Prato não encontrado");
            } else if (!prato.IsAtivo) {
                throw new Exception("Prato inativo");
            }

            TipoRefeicao? tipoRefeicao = await _context.TipoRefeicao.FindAsync(info.TipoRefeicao);
            if (tipoRefeicao == null) {
                throw new Exception("Tipo de refeição não encontrado");
            }

            // Criação da nova refeição
            var newRefeicao = new Refeicao
            {
                Id = info.Id,                
                Prato = prato,
                TipoRefeicao = tipoRefeicao,
                Quantidade = info.Quantidade,                
                Data = info.Data,                    
            };

            // Converte para DTO para retornar a resposta
            return RefeicaoDetail(await _repo.AddRefeicao(newRefeicao));
        }
        //converte um objeto Refeicao em ListarRefeicaoDTO para retornar informações detalhadas
        private ListarRefeicaoDTO RefeicaoDetail(Refeicao r)
        {
            return new ListarRefeicaoDTO
            {
                Id = r.Id,
                Data = r.Data,                    
                TipoRefeicao = r.TipoRefeicao,
                Quantidade = r.Quantidade,
                Prato = r.Prato
            };
        }
        //converte um objeto Refeicao em ListarRefeicaoDTO para retornar apenas informações resumidas
        private ListarRefeicaoDTO RefeicaoListItem(Refeicao r) {
            return new ListarRefeicaoDTO {
                Id = r.Id,
                TipoRefeicao = r.TipoRefeicao,
                Prato = r.Prato,
                Quantidade = r.Quantidade,
                Data = r.Data
            };
        }
        public async Task<List<ListarRefeicaoDTO>> GetRefeicoes() {
            List<Refeicao> Refeicoes = await _repo.GetRefeicoes();

            return Refeicoes.Select(x => RefeicaoListItem(x)).ToList();
        }
        //Retorna uma refeição específica pelo seu id; lança uma exceção se a refeição não for encontrada
        public async Task<ListarRefeicaoDTO> GetRefeicao(int id) {
            Refeicao ?r = await _repo.GetRefeicaoById(id);
            if (r == null)
            {
                throw new Exception("Refeição not found");
            }
            return RefeicaoDetail(r);
        }
        //Servir uma refeição (decrementar quantidade)
        public async Task<ListarRefeicaoDTO> ServirRefeicao(int refeicaoId)
        {
            var refeicao = await _repo.GetRefeicaoById(refeicaoId);
            if (refeicao == null)
            {
                throw new Exception("Refeição não encontrada.");
            }

            if (refeicao.Quantidade <= 0)
            {
                throw new Exception("Não há quantidade suficiente para servir esta refeição.");
            }

            refeicao.Quantidade -= 1;
            var refeicaoAtualizada = await _repo.UpdateRefeicao(refeicao);

            return new ListarRefeicaoDTO
            {
                Id = refeicaoAtualizada.Id,
                Prato = refeicaoAtualizada.Prato,
                Data = refeicaoAtualizada.Data,
                TipoRefeicao = refeicaoAtualizada.TipoRefeicao,
                Quantidade = refeicaoAtualizada.Quantidade
            };
        }
        //Remover uma refeição futura
        public async Task RemoverRefeicaoFutura(int refeicaoId)
        {
            var refeicao = await _repo.GetRefeicaoById(refeicaoId);
            if (refeicao == null)
            {
                throw new Exception("Refeição não encontrada.");
            }

            if (refeicao.Data <= DateTime.Now)
            {
                throw new Exception("A refeição já ocorreu ou está em andamento e não pode ser removida.");
            }

            await _repo.DeleteRefeicao(refeicao);
        }
        //Produzir mais quantidade de uma refeição
        public async Task<ListarRefeicaoDTO> ProduzirRefeicao(int refeicaoId, int quantidadeExtra)
        {
            // Valida quantidade adicional
            if (quantidadeExtra < 1) throw new ArgumentException("A quantidade extra deve ser maior que zero.");

            // Obtém a refeição pelo ID
            var refeicao = await _repo.GetRefeicaoById(refeicaoId);
            if (refeicao == null) throw new Exception("Refeição não encontrada.");

            // Incrementa a quantidade e atualiza no banco de dados
            refeicao.Quantidade += quantidadeExtra;
            await _repo.UpdateRefeicao(refeicao);

            // Retorna o DTO da refeição atualizada
            return new ListarRefeicaoDTO
            {
                Id = refeicao.Id,
                Prato = refeicao.Prato,
                Data = refeicao.Data,
                TipoRefeicao = refeicao.TipoRefeicao,
                Quantidade = refeicao.Quantidade
            };
        }
        public async Task DeleteAllRefeicoes()
        {
            await _repo.DeleteAll();
        }

        
    }
}
