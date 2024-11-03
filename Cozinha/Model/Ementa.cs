using System.ComponentModel.DataAnnotations;

namespace Cozinha.Model;

public class Ementa{
    [Key]
    public long Id { get; set;}
    public required string Frequencia { get; set; } 
    public required DateTime DataInicio { get; set; }
    public required DateTime DataFim { get; set; }
    public required TipoRefeicao TipoRefeicao { get; set;}
    public int Quantidade { get; set;}
    
}