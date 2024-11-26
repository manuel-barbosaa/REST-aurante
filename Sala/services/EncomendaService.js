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
        throw new Error('O cliente não tem saldo suficiente para a encomenda.');
    }

    const debito = -valor; 

    const saldoUpdated = await clienteRepository.updateSaldo(clienteNif, debito);

    if (saldoUpdated) {

        const refeicaoServed = await servirRefeicaoCozinha(ementa.refeicaoId);

        if (refeicaoServed) {
            return await encomendaRepository.createEncomenda({
                cliente: clienteNif,
                data: Date.now(),
                prato: prato,
                valor: valor
            });
        } else {
            throw new Error('O prato não consegue ser servido na cozinha.');
        }
    } else {
        throw new Error('Não foi possível debitar a conta do cliente.');
    }
};

exports.getEncomendasByClienteNIF = async function (nif) {
    try {
        const encomendas = await encomendaRepository.getEncomendas();

        const groupedByCliente = {};

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
        throw new Error("Não foi possível agrupar encomendas por cliente com o NIF fornecido.");
    }
};

exports.getPratosComClientes = async function () {
    try {
        const encomendas = await encomendaRepository.getEncomendas();

        const groupedByPrato = {};

        for (const encomenda of encomendas) {
            const prato = encomenda.prato;
            const clienteNif = encomenda.cliente; 
            const cliente = await clienteRepository.getClienteByNIF(clienteNif);

            if (!groupedByPrato[prato]) {
                groupedByPrato[prato] = new Set(); 
            }

            groupedByPrato[prato].add(cliente.nome);
        }

        const result = {};
        for (const prato in groupedByPrato) {
            result[prato] = Array.from(groupedByPrato[prato]);
        }

        return result;
    } catch (error) {
        throw new Error("Não foi possível agrupar clientes por prato.");
    }
};

exports.deleteEncomenda = async function (id) {
    return await encomendaRepository.deleteEncomenda(id);
}