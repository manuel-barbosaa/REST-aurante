const EncomendaModel = require("../models/encomenda");



exports.createEncomenda = async function(encomendaDTO){
    const encomenda  = new EncomendaModel(encomendaDTO);
    
    try{
        await encomenda.save();
        return true;
    }catch (err){
        throw new Error({message: "repo"});
    }
}

exports.getEncomendasByCliente = async function (clienteId){

    return await EncomendaModel.find({ cliente: clienteId}).sort({data: -1});
    
};

