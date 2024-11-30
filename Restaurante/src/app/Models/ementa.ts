export interface Ementa {
  id: number;         // ID único da ementa
  refeicaoId: number; // ID da refeição associada à ementa
  frequencia: string; // Frequência da ementa (ex.: "Diária", "Semanal")
  pratos: Array<{     // Lista de pratos já incluídos na ementa
    id: number;       // ID do prato
    nome: string;     // Nome do prato
    preco: number;    // Preço do prato
    tipoRefeicao: string; // Tipo de refeição (ex.: "Almoço", "Entrada")
  }>;
}
