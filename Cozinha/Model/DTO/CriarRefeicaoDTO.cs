namespace Cozinha.Model.DTO;

public class CriarRefeicaoDTO {
    public int Id { get; set;}
    public required Prato prato { get; set;}
    public required TipoRefeicao tipo { get; set;}
    public int quantidade { get; set;}
    public DateTime data{ get; set;}    
}