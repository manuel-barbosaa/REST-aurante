const ementa = require("../models/ementa");
const EmentaModel = require("../models/ementa");


exports.createEmenta = async function(ementaData){
    const ementa = new EmentaModel(ementaData);
    
    try{
        await ementa.save();
        return true;
    }catch (err){
        throw new Error({message: "repo"});
    }
}



exports.getEmentaByRefeicaoId = async function (refeicaoId) {
    try {
        // Verifica se refeicaoId é um número válido
        if (isNaN(Number(refeicaoId))) {
            throw new Error('O ID da refeição deve ser um número válido.');
        }

        const ementa = await EmentaModel.find({ refeicaoId: Number(refeicaoId) });

        if (!ementa || ementa.length === 0) {
            throw new Error('Nenhuma ementa encontrada para o ID da refeição fornecido.');
        }

        return ementa;
    } catch (err) {
        throw new Error(`Erro a procurar ementa atraves do ID: ${err.message}`);
    }
};
