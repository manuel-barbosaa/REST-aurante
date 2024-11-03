namespace Cozinha.Model.DTO;

public class ListarEmentaDTO{
    public required long Id { get; set;}
    public required string Frequencia { get; set; } 
    public required DateTime DataInicio { get; set; }
    public required DateTime DataFim { get; set; }
        
    // Relação com as refeições incluídas na ementa
    public required List<Refeicao> Refeicoes { get; set; } = new List<Refeicao>();
}
