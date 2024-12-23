using Microsoft.EntityFrameworkCore;
namespace Cozinha.Model;

public class CozinhaContext : DbContext
{
    public CozinhaContext(DbContextOptions<CozinhaContext> opt) : base(opt) { }

    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<TipoPrato> TiposPrato { get; set; }
    public DbSet<Prato> Pratos { get; set; }

    public DbSet<TipoRefeicao> TipoRefeicao{get; set;}
    public DbSet<Refeicao> Refeicao{get;set;}
    public DbSet<Ementa> Ementas{get;set;}
    
    



    
}