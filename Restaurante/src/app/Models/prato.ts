export interface Prato {
    id: number;
    nome: string;
    isAtivo: string;
    tipoPrato: {
      id: number, nome: string
    };
    ingredientes: string;
    receita: string;
  }