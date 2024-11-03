namespace Cozinha.Model.DTO;

public class ListarPratoDTO
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required bool IsAtivo { get; set; } = true;
    public virtual TipoPrato TipoPrato { get; set; } 
    public virtual required List<Ingrediente> Ingredientes { get; set; }
    
    public string Receita { get; set; }
}
