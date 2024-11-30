export interface Prato {
  id: number;
  nome: string;
}

export interface Ementa {
  id: string;
  prato: Prato;
  refeicaoId: number;
  preco: number;
  criadoEm: Date;
}
