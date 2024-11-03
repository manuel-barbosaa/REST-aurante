namespace Cozinha.Model.DTO;

public class CriarEmentaDTO
{
    public required string Frequencia { get; set; } 
    public required DateTime DataInicio { get; set; }
    public required DateTime DataFim { get; set; }

    public required TipoRefeicao TipoRefeicao { get; set;}
    public int Quantidade { get; set;}
   
}
