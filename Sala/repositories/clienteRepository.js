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