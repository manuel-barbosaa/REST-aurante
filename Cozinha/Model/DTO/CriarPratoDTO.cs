namespace Cozinha.Model.DTO;

public class CriarPratoDTO
{
        public long Id { get; set; }
        public required string Nome { get; set; }

        public required bool IsAtivo { get; set; } = true;

        // Tipo de Prato
        public virtual required TipoPrato TipoPrato { get; set; }
        //Ingredientes
        public virtual required List<Ingrediente> Ingredientes { get; set; }
}
