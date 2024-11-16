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