namespace Cozinha.Model.DTO;

public class CriarIngredienteDTO
{
    public required string Nome { get; set; }
    public required string CategoriaAlimenticia { get; set; }
    public required bool Ativo { get; set; }
}