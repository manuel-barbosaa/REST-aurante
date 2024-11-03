using Cozinha.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cozinha.Repositories
{
    public class EmentaRepository
    {
        private readonly CozinhaContext _context;

        public EmentaRepository(CozinhaContext context)
        {
            _context = context;
        }

        // Método para buscar uma ementa pelo ID
        public async Task<Ementa?> GetEmentaById(long id)
        {
            return await _context.Ementas
                .Include(e => e.TipoRefeicao)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    //    // Método para buscar ementas por tipo de refeição, quantidade > 0 e data específica.
    //     public async Task<List<Ementa>> GetEmentaByTipoQuantidadeData(long tipoRefeicaoId, DateTime data)
    //     {
    //         return await _context.Ementas
    //             .Include(e => e.TipoRefeicao)
    //             .Where(e => e.TipoRefeicao.Id == tipoRefeicaoId 
    //                         && e.Quantidade > 0 
    //                         && e.DataInicio <= data 
    //                         && e.DataFim >= data)
    //             .ToListAsync();
    //     }

        // Método para adicionar uma nova ementa
        public async Task<Ementa> AddEmenta(Ementa ementa)
        {
            var newEmenta = await _context.Ementas.AddAsync(ementa);
            await _context.SaveChangesAsync();
            return newEmenta.Entity;
        }

        // Método para remover uma ementa
        public async Task<bool> RemoveEmenta(Ementa ementa)
        {
            _context.Ementas.Remove(ementa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
