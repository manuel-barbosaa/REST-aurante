 
const Cliente = require('../models/cliente');

// Função para validar a existência de um cliente pelo NIF - UC3
const validarClientePorNif = async (nif) => {
    try {
        const cliente = await Cliente.findOne({ nif: nif });
        if (!cliente) {
            throw new Error('Cliente não encontrado');
        }
        return cliente; 
    } catch (err) {
        throw err; 
    }
};

// Função para obter a informação básica do cliente - UC3
const obterInformacoesCliente = async (nif) => {
    try {
        const cliente = await Cliente.findOne({ nif: nif }, 'nome nif email');
        if (!cliente) {
            throw new Error('Cliente não encontrado');
        }
        return cliente; // Retorna apenas os campos nome, nif e email
    } catch (err) {
        throw err; 
    }
};

module.exports = {
    validarClientePorNif,
    obterInformacoesCliente
};
