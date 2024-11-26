const ementa = require("../models/ementa");
const EmentaModel = require("../models/ementa");


exports.createEmenta = async function(ementaData){
    const ementa = new EmentaModel(ementaData);
    
    try{
        await ementa.save();
        return true;
    }catch (err){
        throw new Error('Não foi possível criar a ementa. Tente novamente.');
    }
}

exports.getEmentas = async function () {
    try {
        return EmentaModel.find();
    } catch(err) {
        throw new Error('Erro a obter ementas. Tente novamente.')
    }
}

exports.getEmentaByRefeicaoId = async function (refeicaoId) {
    try {
        const ementa = await EmentaModel.find({ refeicaoId: Number(refeicaoId) });

        if (!ementa || ementa.length === 0) {
            throw new Error('Nenhuma ementa encontrada para o ID da refeição fornecido.');
        }

        return ementa;
    } catch (err) {
        throw new Error(`N#ao foi poss]ivel procurar a ementa pelo ID da refeição. Tente novamente.`);
    }
};

exports.getEmentaById = async function (id) {
    try {
        return await EmentaModel.findOne({ _id: id });
    } catch(err) {
        throw new Error('Não foi possível encontrar uma ementa com o ID fornecido. Tente novamente.')
    }
}


exports.deleteEmentaById = async function (id) {
    try {
        return await EmentaModel.deleteOne({ _id: id });
    } catch (error) {
        throw new Error('Erro ao eliminar ementa pelo ID.');
    }
};
exports.deleteAllEmenta = async function(){
    try {
        return await EmentaModel.deleteMany({});
    } catch (error) {
        throw new Error('Erro ao eliminar todas as ementas');
    }
}
