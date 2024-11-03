namespace Cozinha.Model.DTO;

public class ListarEmentaDTO{
    public required long Id { get; set;}
    public required string Frequencia { get; set; } 
    public required List<ListarRefeicaoDTO> Refeicoes {get; set;}
}
