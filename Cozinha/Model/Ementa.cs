using System.ComponentModel.DataAnnotations;

namespace Cozinha.Model;

public class Ementa{
    [Key]
    public long Id { get; set;}
    public required string Frequencia { get; set; } 
    public required DateTime DataInicio { get; set; }
    public required DateTime DataFim { get; set; }
        
    // Relação com as refeições incluídas na ementa
    public required List<Refeicao> Refeicoes { get; set; } = new List<Refeicao>();
}