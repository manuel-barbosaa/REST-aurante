const ClienteModel = require('../models/cliente');
const { getClienteByNIF } = require('../services/clienteService');

exports.getClientes = async function() {
    return ClienteModel.find();
}

exports.createCliente = async function (clienteData){
    const cliente = new ClienteModel(clienteData);
    try{
        await cliente.save();
        return true;
    }catch (err){
        return false;
    }
}

exports.getClienteByNIF = async function (nif) {
    return await ClienteModel.findOne({ nif });
}

exports.getClienteSaldo = async function (nif) {
    const cliente = await ClienteModel.findOne({ nif });
    return cliente ? { saldo: cliente.saldo } : null;
}

exports.updateSaldo = async function (clienteNIF, quantia) {
    try {
        // Usando o método getClienteByNIF para buscar o cliente
        const cliente = await this.getClienteByNIF(clienteNIF);
        
        if (!cliente) {
            return false;
        }


        cliente.saldo += quantia;

        
        await cliente.save();

        return cliente; 
    } catch (err) {
       return false;
    }
}