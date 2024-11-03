using Cozinha.Model.DTO;
using Cozinha.Model;
using Cozinha.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cozinha.Services
{
    public class EmentaService
    {
        private readonly EmentaRepository _repo;
        private CozinhaContext _context;

        public EmentaService(CozinhaContext context) {
            _context = context;
            _repo = new EmentaRepository(_context);
        }

        public async Task<List<ListarEmentaDTO>> GetEmentas() {
            List<Ementa> Ementas = await _repo.GetEmentas();

            return Ementas.Select(x => EmentaListItem(x)).ToList();
        }

        public async Task<ListarEmentaDTO> GetEmentaById(long id) {
            Ementa? e = await _repo.GetEmentaById(id);
            if (e == null)
            {
                throw new Exception("Ementa not found");
            }
            return EmentaListItem(e);
        }

public async Task<ListarEmentaDTO> CreateNewEmenta(CriarEmentaDTO info)
{
    // Check for provided Refeicoes in the request
    if (info.Refeicoes == null || !info.Refeicoes.Any())
    {
        throw new Exception("ExistingRefeicaoIds must be provided");
    }

    List<Refeicao> refeicoes = new List<Refeicao>();

    // Fetch and add each Refeicao based on provided IDs
    foreach (var id in info.Refeicoes)
    {
        var refeicaoAux = await _context.Refeicao
            .Include(r => r.Prato) // Ensure Prato is included
            .Include(r => r.TipoRefeicao) // Ensure TipoRefeicao is included
            .FirstOrDefaultAsync(r => r.Id == id);

        if (refeicaoAux != null)
        {
            // Make sure we are not modifying the original Refeicao
            // Add the fetched Refeicao
            refeicoes.Add(refeicaoAux);
        }
        else
        {
            throw new Exception($"Refeicao with Id {id} not found");
        }
    }

    // Create a new Ementa with the fetched Refeicoes
    Ementa ementa = new Ementa
    {
        Frequencia = info.Frequencia,
        Refeicoes = refeicoes // Here, we're reusing the existing Refeicao instances
    };

    // Add the Ementa to the database
    // Save changes will be called later to ensure it's added correctly
    var createdEmenta = await _repo.AddEmenta(ementa);

    // Return the DTO for the created Ementa
    return EmentaListItem(createdEmenta);
}

// Assuming EmentaListItem correctly converts to ListarEmentaDTO
private ListarEmentaDTO EmentaListItem(Ementa e)
{
    return new ListarEmentaDTO
    {
        Id = e.Id,
        Frequencia = e.Frequencia,
        Refeicoes = e.Refeicoes.Select(r => new ListarRefeicaoDTO
        {
            Id = r.Id,
            Prato = r.Prato, // Ensure this is not null
            TipoRefeicao = r.TipoRefeicao, // Ensure this is not null
            Quantidade = r.Quantidade,
            Data = r.Data
        }).ToList()
    };
}


        // private ListarEmentaDTO EmentaListItem(Ementa e) {
        //     return new ListarEmentaDTO {
        //         Id = e.Id,
        //         Frequencia = e.Frequencia,
        //         Refeicoes = e.Refeicoes
        //     };
        // }


        // private ListarEmentaDTO EmentaListItem(Ementa e)
        // {
        //     return new ListarEmentaDTO
        //     {
        //         Id = e.Id,
        //         Frequencia = e.Frequencia,
        //         Refeicoes = e.Refeicoes.Select(r => new ListarRefeicaoDTO
        //         {
        //             Id = r.Id,
        //             Prato = r.Prato,  // Safely access the Prato's name
        //             TipoRefeicao = r.TipoRefeicao, // Safely access the TipoRefeicao's name
        //             Quantidade = r.Quantidade,
        //             Data = r.Data
        //         }).ToList()
        //     };
        // }

            public async Task<bool> DeleteEmenta(long id)
        {
            var ementa = await _context.Ementas.FindAsync(id);
            if (ementa == null)
            {
                return false;
            }
            _context.Ementas.Remove(ementa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
