namespace Cozinha.Model.DTO;

public class ListarIngredienteDTO
{
    public required string Nome { get; set; }
    public string CategoriaAlimenticia { get; set; }
    public bool Ativo { get; set; }
}
