using Cozinha.Model;
using Cozinha.Model.DTO;
using Cozinha.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Services {
    public class RefeicaoService {

        private  CozinhaContext _context;
        private  RefeicaoRepository _repo;
        private  PratoRepository _pratoRepo;

        public RefeicaoService(CozinhaContext context) {
            _context = context;
            _repo = new RefeicaoRepository(_context);
            _pratoRepo = new PratoRepository(_context); 
        }
        public async Task<ListarRefeicaoDTO> AddRefeicao(CriarRefeicaoDTO info)
        {
           // Verificar se o prato existe e está ativo
            var prato = await _pratoRepo.GetPratoById(info.Id);
            if (prato == null || !prato.IsAtivo)
            {
                throw new Exception("O prato selecionado não existe ou está inativo.");
            }

            // Criação da nova refeição
            var newRefeicao = new Refeicao
            {
                Id = info.Id,
                Data = info.data,                    
                TipoRefeicao = info.tipo,
                Quantidade = info.quantidade,
                Prato = prato
            };

            // Adiciona a refeição ao banco de dados através do repositório
            var refeicaoCriada = await _repo.AddRefeicao(newRefeicao);

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
        public async Task<List<ListarRefeicaoDTO>> GetRefeicao() {
            List<Refeicao> Refeicoes = await _repo.GetRefeicao();

            return Refeicoes.Select(x => RefeicaoListItem(x)).ToList();
        }
    }
}
