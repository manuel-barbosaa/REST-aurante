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
    const prato= ementa.prato.nome;
    const valor= ementa.preco; 
    const cliente= await clienteRepository.getClienteByNIF(clienteNif);
    if(cliente.saldo< valor){
        console.log('ta broke');
       return false;
    
    }

    const debito = -valor; 

    const saldoUpdated = await clienteRepository.updateSaldo(clienteNif, debito);

    if (saldoUpdated) {
        console.log('debitou');
        const refeicaoServed = await servirRefeicaoCozinha(ementa.refeicaoId);

        if (refeicaoServed) {
            console.log('serviu');
            return await encomendaRepository.createEncomenda({
                cliente: clienteNif,
                data: Date.now(),
                prato: prato,
                valor: valor
            });
        }
    }
};

exports.getEncomendasByClienteNIF = async function (nif) {
    try {
        // Fetch all encomendas
        const encomendas = await encomendaRepository.getEncomendas();

        // Prepare the result object
        const groupedByCliente = {};

        // Process each encomenda
        for (const encomenda of encomendas) {
            const clienteNif = encomenda.cliente;

            if (!groupedByCliente[clienteNif]) {
                groupedByCliente[clienteNif] = []; 
            }

            groupedByCliente[clienteNif].push({
                prato: encomenda.prato,
                valor: encomenda.valor,
                data: encomenda.data,
            });
        }

        return groupedByCliente;
    } catch (error) {
        console.error("Error grouping encomendas by cliente", error);
        throw new Error("Could not group encomendas by cliente");
    }
};

exports.getClientesByPrato = async function(){
    const encomendas = await encomendaRepository.getClientesByPrato();

    const list = {};

    encomendas.forEach(({prato, cliente})=>{
        if(!list[prato]){
            list[prato] = new Set();
        }
        list[prato].add(cliente.nif);
        list[prato].add(cliente.nome);
    });

    for(const prato in list){
        list[prato]= Array.from(list[prato]);
    }

    return list;
}