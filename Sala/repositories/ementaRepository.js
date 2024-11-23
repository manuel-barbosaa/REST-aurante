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

exports.getEmentas = async function () {
    return EmentaModel.find();
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

exports.getEmentaById = async function (id) {
    return await EmentaModel.findOne({ _id: id });
}


exports.deleteEmentaById = async function (id) {
    try {
        const result = await EmentaModel.deleteOne({ _id: id });
        return result;
    } catch (error) {
        console.error('Erro ao eliminar ementa pelo ID:', error);
        return false;
    }
};
exports.deleteAllEmenta = async function(){
    try {
        await EmentaModel.deleteMany({});
        return true;
    } catch (error) {
        console.error('Erro ao eleminar todas as ementas:', error);
        return false;
    }
}
