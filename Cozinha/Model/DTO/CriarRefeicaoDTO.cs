namespace Cozinha.Model.DTO;

public class CriarRefeicaoDTO {
    public long Id { get; set;}
    public required long Prato { get; set;}
    public required long TipoRefeicao { get; set;}
    public int Quantidade { get; set;}
    public DateTime Data{ get; set;}    
}