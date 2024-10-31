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
    }
}
