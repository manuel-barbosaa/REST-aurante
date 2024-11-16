const EmentaService = require('../services/ementaService');

exports.createEmenta= async function (req, res){
    const result = await EmentaService.createEmenta(req.body);

    if(!result){
        res.status(404).send('Erro ao criar ementa');
    } else{
        res.status(201).json({message: 'Ementa criada com sucesso'});
    }
}