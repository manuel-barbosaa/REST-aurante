using Cozinha.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cozinha.Repositories
{
    public class EmentaRepository
    {
        private CozinhaContext _context;
        //construtor do repositório, inicializa o contexto
        public EmentaRepository(CozinhaContext context) {
            _context = context;
        }
        // Método para obter uma ementa por tipo e intervalo de datas
        public async Task<Ementa?> GetEmentaByTipoEData(string tipo, DateTime dataInicio, DateTime dataFim)
        {
            return await _context.Ementa
                .Include(e => e.Refeicoes)
                .ThenInclude(r => r.Prato)
                .Include(e => e.Refeicoes)
                .ThenInclude(r => r.TipoRefeicao)
                .FirstOrDefaultAsync(e => e.Frequencia == tipo && e.DataInicio <= dataFim && e.DataFim >= dataInicio);
        }

        // Método para adicionar uma nova ementa
        public async Task AddEmenta(Ementa ementa)
        {
            _context.Ementa.Add(ementa);
            await _context.SaveChangesAsync();
        }

         public async Task<TipoRefeicao?> GetEmentayId(long id) {
            return await _context.TipoRefeicao.FindAsync(id);
        }



         public async Task<bool> RemoveEmenta(Ementa ementa)
        {
            _context.Ementa.Remove(ementa);
            await _context.SaveChangesAsync();
            return true;
        }

        internal async Task<Ementa> GetEmentaById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
