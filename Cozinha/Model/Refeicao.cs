namespace Cozinha.Model;

public class Refeicao{
    public int Id { get; set;}
    public required Prato Prato { get; set;}
    public required TipoRefeicao TipoRefeicao { get; set;}
    public int Quantidade { get; set;}
    public DateTime Data{ get; set;}    
}