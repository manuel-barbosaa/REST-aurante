const ClienteModel = require('../models/cliente');

const ClienteRepo = require('../repositories/clienteRepository')

exports.getClientes = async function () {
    const allClientes = await ClienteRepo.getClientes();
    iList = new Array();
    allClientes.forEach(
        (i) => {
            iList.push({
                'nome': i.nome,
                'nif': i.nif,
                'email': i.email,
            })
        }
    );
    return iList
}

exports.createCliente = async function (clienteDTO){
    return await ClienteRepo.createCliente({
        nome: clienteDTO.nome,
        nif: clienteDTO.nif,
        email: clienteDTO.email,
        saldo: clienteDTO.saldo
    });
}

exports.deposit = async function (clienteId, quantia) {
    return await ClienteRepo.updateSaldo(clienteId, quantia);
} 