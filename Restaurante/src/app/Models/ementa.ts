import { Prato } from "./prato";

export interface Ementa {
  id: string;
  prato: Prato;
  refeicaoId: number;
  preco: number;
  criadoEm: Date;
}
