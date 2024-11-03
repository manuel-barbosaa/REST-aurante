namespace Cozinha.Model.DTO;

public class CriarEmentaDTO
{
    public required string Frequencia { get; set; } 
    public required DateTime DataInicio { get; set; }
    public required DateTime DataFim { get; set; }
    public List<long> Refeicoes { get; set; } = new List<long>(); 
}
