using REST_aurante.Cozinha.Model;

namespace Cozinha.Model.DTO;

public class ListarIngredienteDTO
{
    public string Nome { get; set; }
    public string CategoriaAlimenticia { get; set; }
    public bool Ativo { get; set; }
}