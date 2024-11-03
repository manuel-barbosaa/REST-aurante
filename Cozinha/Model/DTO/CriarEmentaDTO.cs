namespace Cozinha.Model.DTO;

public class CriarEmentaDTO
{
    public required string Frequencia { get; set; } 
    public  List<long> Refeicoes  { get; set; } = new List<long>(); 
   
}
