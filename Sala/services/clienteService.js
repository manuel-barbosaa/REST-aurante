const ClienteModel = require('../models/cliente');

const ClienteRepo = require('../repositories/clienteRepository')

exports.createCliente = async function (clienteDTO){
    return await ClienteRepo.createCliente({
        nome: clienteDTO.nome,
        nif: clienteDTO.nif,
        email: clienteDTO.email,
        balance: clienteDTO.balance
    });
}