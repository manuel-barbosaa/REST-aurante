export interface Refeicao {
    id: number;
    prato: {
      id: number;
      nome: string;
      isAtivo: boolean;
      tipoPrato: {
        id: number;
        nome: string;
      };
      ingredientes: {
        id: number;
        nome: string;
        categoriaAlimenticia: string;
        ativo: boolean;
      }[];
      receita: string;
    };
    tipoRefeicao: {
      id: number;
      nome: string;
      descricao: string;
    };
    quantidade: number;
    data: string;
  }
  