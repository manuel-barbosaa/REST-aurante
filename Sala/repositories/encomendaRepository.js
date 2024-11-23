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

exports.getEncomendasByClienteNIF = async function (nif){
    try{

        return await EncomendaModel.find({ "cliente.nif": nif}).populate('cliente', 'nif nome').exec();

    } catch (err){

        console.error("Erro a ir buscar encomendar por NIF", err);

        return null;
    }
   
};

exports.getPratosComClientes = async function () {
    try {
        // Obtém todas as encomendas e popula os detalhes dos clientes
        return await EncomendaModel.find({ cliente: { $ne: null } })
            .populate('cliente', 'nif nome') // Preenche os campos "nif" e "nome" do cliente
            .exec();
    } catch (err) {
        console.error("Erro ao buscar pratos com clientes:", err);
        return null;
    }
};

