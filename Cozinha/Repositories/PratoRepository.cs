using Cozinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Repositories{
    public class PratoRepository {
        //contexto de banco de dados para manipular as operações relacionadas ao modelo de prato
        private CozinhaContext _context;
        //construtor do repositório, inicializa o contexto
        public PratoRepository(CozinhaContext context) {
            _context = context;
        }

        //obtem todos os pratos
        public async Task<List<Prato>> GetPrato() {
            return await _context.Pratos.Include(p => p.TipoPrato).
                                         Include(p => p.Ingredientes).
                                         ToListAsync();
        }

// Obtem um prato pelo seu id e carrega as propriedades relacionadas
        public async Task<Prato?> GetPratoById(long id)
        {
            return await _context.Pratos
                .Include(p => p.TipoPrato)    // Inclui TipoPrato
                .Include(p => p.Ingredientes) // Inclui Ingredientes
                .FirstOrDefaultAsync(p => p.Id == id); // Usa FirstOrDefaultAsync para a busca
        }


        //obtem um prato pelo seu nome
        public async Task<Prato?> GetPratoByNome(string nome) {
            return await _context.Pratos.FirstOrDefaultAsync(tp => tp.Nome.Equals(nome));
        }

        //obtem pratos pelo tipo de prato (exemplo: carne, peixe, vegetariano)
        public async Task<List<Prato>> GetPratoByTipoPrato(TipoPrato tipoPrato) {
            return await _context.Pratos.Where(p => p.TipoPrato.Equals(tipoPrato)).ToListAsync();
        }

        //obtem pratos que têm um ingrediente específico
        public async Task<List<Prato>> GetPratoByIngrediente(Ingrediente ingrediente) {
            return await _context.Pratos.Where(p => p.Ingredientes.Contains(ingrediente)).ToListAsync();
        }

        //obtem pratos que têm um ingrediente esepcifico pelo nome do ingrediente
        public async Task<List<Prato>> GetPratoByIngredienteNome(string nome) {
            return await _context.Pratos.Where(p => p.Ingredientes.Any(i => i.Nome.Equals(nome))).ToListAsync();
        }

        //obtem pratos combase no estado (ativos ou inativos)
        public async Task<List<Prato>> GetPratosByState(bool IsAtivo)
        {
            return await _context.Pratos.Where(i => i.IsAtivo == IsAtivo).
                Include(p => p.TipoPrato).    // Inclui TipoPrato
                Include(p => p.Ingredientes).
                ToListAsync();
        } 

        //atualiza um prato no banco de dados
        public async Task<Prato> UpdatePrato(Prato prato)
        {
            _context.Entry(prato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return prato;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        //adiciona um novo prato no banco de dados
        public async Task<Prato> AddPrato(Prato prato)
        {
            var newPrato = await _context.Pratos.AddAsync(prato);

            await _context.SaveChangesAsync();
            return newPrato.Entity;
        }

        //remove um prato do banco de dados
        public async Task<bool> Remove(Prato prato)
        {
            _context.Pratos.Remove(prato);
            await _context.SaveChangesAsync();
            return true;
        }


        //US009- Inativação de um Ingrediente e todos os pratos que dependem dele
        public async Task InativarIngrediente(Ingrediente ingrediente)
        {
            ingrediente.Ativo = false; //define o ingrediente como inativo
            
            //obtem todos os pratos que contém o ingrediente inativado
            var pratosDependentes = _context.Pratos
                .Where(p => p.Ingredientes.Contains(ingrediente)).ToList();

            //inativa todos os pratos que dependem do ingrediente inativado
            foreach (var prato in pratosDependentes)
            {
                prato.IsAtivo = false;
            }

            await _context.SaveChangesAsync();
        }

         //US010- Ativação de um Ingrediente e reativa pratos que dependem apenas de ingredientes ativos     
        public async Task AtivarIngrediente(Ingrediente ingrediente)
        {
            ingrediente.Ativo = true;  //define o ingrediente como ativo


            //obtem todos os pratos que contém o ingrediente agora ativo
            var pratosDependentes = _context.Pratos
                .Where(p => p.Ingredientes.Contains(ingrediente)).ToList();

            //verifica se todos os ingredientes do prato estão ativos, se sim, ativa o prato
            foreach (var prato in pratosDependentes)
            {
                if (prato.Ingredientes.All(i => i.Ativo))
                {
                    prato.IsAtivo = true;
                }
            }

            await _context.SaveChangesAsync();
        }




    } 
}