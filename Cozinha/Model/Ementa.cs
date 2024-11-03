namespace Cozinha.Model;

public class Ementa{
    public int Id { get; set;}
    public string Frequencia { get; set; } 
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
        
    // Relação com as refeições incluídas na ementa
    public List<Refeicao> Refeicoes { get; set; } = new List<Refeicao>();
    }