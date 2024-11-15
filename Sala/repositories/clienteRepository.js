const ClienteModel = require('../models/cliente');

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

exports.updateSaldo = async function(clienteId, quantia) {
    try {
        const result = await ClienteModel.findByIdAndUpdate(
            clienteId,
            { $inc: { saldo: quantia } },
            { new: true }
        );

        return result !== null;
    } catch (err) {
        return false;
    }
}