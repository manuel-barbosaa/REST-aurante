namespace Cozinha.Model.DTO;

public class CriarPratoDTO
{
    public required string Nome { get; set; }
    public required bool IsAtivo { get; set; }
    public required long TipoPrato { get; set; }
    public List<long> Ingredientes { get; set; } = new List<long>(); 
    public required string Receita { get; set; }
}
