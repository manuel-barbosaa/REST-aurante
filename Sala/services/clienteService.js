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

exports.getClienteByNIF = async function (nif) {
    return await ClienteRepo.getClienteByNIF(nif);
}

exports.getClienteSaldo = async function (nif) {
    return await ClienteRepo.getClienteSaldo(nif);
}

exports.deposit = async function (clienteId, quantia) {
    if (quantia <= 0) {
        return false;
    }
    return await ClienteRepo.updateSaldo(clienteId, quantia);
}

exports.deleteClienteByNIF = async function (nif) {
    return await ClienteRepo.deleteClienteByNIF(nif);
};

exports.deleteAllClientes = async function () {
    return await ClienteRepo.deleteAllClientes();
};
