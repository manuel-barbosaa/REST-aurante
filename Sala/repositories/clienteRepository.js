const ClienteModel = require('../models/cliente');

exports.createCliente = async function (clienteData){
    const cliente = new ClienteModel(clienteData);
    try{
        await cliente.save();
        return true;
    }catch (err){
        return false;
    }
}