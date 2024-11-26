const EncomendaModel = require("../models/encomenda");



exports.createEncomenda = async function(encomendaDTO){
    const encomenda  = new EncomendaModel(encomendaDTO);
    
    try{
        await encomenda.save();
        return true;
    }catch (err){
        throw new Error('Não foi possível criar a encomenda. Tente novamente.');
    }
}

exports.getEncomendas = async function () {
    try {
        return await EncomendaModel.find();
    } catch (error) {
        throw new Error("Não foi possível procurar as encomendas. Tente novamente.");
    }
};

exports.getEncomendasByClienteNIF = async function (nif){
    try{
        return await EncomendaModel.find({ "cliente.nif": nif}).populate('cliente', 'nif nome').exec();
    } catch (err){
        throw new Error('Não foi possível procurar a encomenda com o NIF fornecido. Tente novamente.');
    }
   
};

exports.deleteEncomenda = async function(id) {
    try {
        return await EncomendaModel.deleteOne({ _id: id});
    } catch (err) {
        throw new Error('Não foi possível apagar a encomenda com o ID fornecido. Tente novamente.');
    }
}
