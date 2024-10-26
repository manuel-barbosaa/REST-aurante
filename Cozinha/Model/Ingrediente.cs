namespace Cozinha.Model;

public class Ingrediente
{
    public required string Nome { get; set; }
    public required string CategoriaAlimenticia { get; set; }
    public bool Ativo { get; set; }
}
