using System.ComponentModel.DataAnnotations;

namespace Cozinha.Model;

public class Ementa{
    [Key]
    public long Id { get; set;}
    public required string Frequencia { get; set; } 
    public required List<Refeicao> Refeicoes { get; set;}
    
}