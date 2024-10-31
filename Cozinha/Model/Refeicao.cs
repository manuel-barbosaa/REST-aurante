namespace Cozinha.Model;

public class Refeicao{
    public int Id { get; set;}
    public required Prato prato { get; set;}
    public required TipoRefeicao tipoRefeicao { get; set;}
    public int quantidade { get; set;}
    public DateTime data{ get; set;}    
}