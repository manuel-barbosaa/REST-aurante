namespace Cozinha.Model;

public class Refeicao{
    public long Id { get; set;}
    public required Prato Prato { get; set;}
    public required TipoRefeicao TipoRefeicao { get; set;}
    public int Quantidade { get; set;}
    public DateTime Data{ get; set;}    
}