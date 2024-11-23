const EncomendaModel = require("../models/encomenda");



exports.createEncomenda = async function(encomendaDTO){
    const encomenda  = new EncomendaModel(encomendaDTO);
    console.log(encomenda);
    console.log("testN");
    
    try{
        await encomenda.save();
        return true;
    }catch (err){
        throw new Error({message: "repo"});
    }
}

exports.getEncomendas = async function () {
    try {
        return await EncomendaModel.find();
    } catch (error) {
        console.error("Error fetching encomendas", error);
        throw new Error("Could not fetch encomendas");
    }
};

exports.getEncomendasByClienteNIF = async function (nif){
    try{

        return await EncomendaModel.find({ "cliente.nif": nif}).populate('cliente', 'nif nome').exec();

    } catch (err){

        console.error("Erro a ir buscar encomendar por NIF", err);

        return null;
    }
   
};

exports.getClientesByPrato = async function () {
    try {
        const encomendas = await EncomendaModel.find().populate("cliente", "nif nome").exec();
        return encomendas;
    } catch (err) {
        console.error("Não existem encomendas");
        return null;
    }
};

