using System.ComponentModel.DataAnnotations;

namespace Cozinha.Model;

public class TipoPrato {
    public long Id { get; set;}
    public required string Nome { get; set;}
}