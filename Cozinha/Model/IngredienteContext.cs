using Microsoft.EntityFrameworkCore;
using REST_aurante.Cozinha.Model;

namespace Cozinha.Model;

public class IngredienteContext : DbContext
{
    public IngredienteContext(DbContextOptions<IngredienteContext> opt) : base(opt) { }

    public DbSet<Ingrediente> Ingredientes { get; set; }
    
}