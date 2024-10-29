namespace Cozinha.Model.DTO;

public class ListarIngredienteDTO
{
    public required int Id { get; set; }
    public required string Nome { get; set; }
    public required string CategoriaAlimenticia { get; set; }
    public bool Ativo { get; set; }
}
