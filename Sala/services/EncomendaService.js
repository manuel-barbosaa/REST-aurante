const webApiClient = require('axios').default;
const ementaRepository= require("../repositories/ementaRepository")
const clienteRepository= require("../repositories/clienteRepository")
const encomendaRepository= require("../repositories/encomendaRepository")

async function servirRefeicaoCozinha(refeicaoId) {
    process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;   // Inibe a vericação dos certificados

    const cozinhaWebAPIURL = 'http://localhost:5230/api/Refeicao/';

    try {

        const result = await webApiClient.put(`${cozinhaWebAPIURL}${refeicaoId}/servir`);

        if (result.status === 200) {
            return true;
        }

        return false;
    } catch (error) {
        console.error('Erro ao servir a refeição', error);
        return false;
    }
}

exports.createEncomenda = async function(ementaId, clienteNif){
    
    const ementa= await ementaRepository.getEmentaById(ementaId);
    console.log(ementa);
    const prato= ementa.prato.nome;
    const valor= ementa.preco; 
    const cliente= await clienteRepository.getClienteByNIF(clienteNif);

    if(cliente.saldo< valor){
       return false;
    
    }

    const debito = -valor; 

    const saldoUpdated = await clienteRepository.updateSaldo(clienteNif, debito);

    if (saldoUpdated) {

        const refeicaoServed = await servirRefeicaoCozinha(ementa.refeicaoId);

        if (refeicaoServed) {

            return await encomendaRepository.createEncomenda({
                cliente: cliente,
                data: Date.now(),
                prato: prato,
                valor: valor
            });
        }
    }
};

