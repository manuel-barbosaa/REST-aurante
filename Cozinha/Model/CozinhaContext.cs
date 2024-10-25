using Microsoft.EntityFrameworkCore;
using REST_aurante.Cozinha.Model;

namespace Cozinha.Model;

public class CozinhaContext : DbContext
{
    public CozinhaContext(DbContextOptions<CozinhaContext> opt) : base(opt) { }

    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<TipoPrato> TiposPrato { get; set; }
    
}