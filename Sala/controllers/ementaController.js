const EmentaService = require('../services/ementaService');

exports.createEmenta= async function (req, res){
    const result = await EmentaService.createEmenta(req.body);

    if(!result){
        res.status(404).send('Erro ao criar ementa');
    } else{
        res.status(201).json({message: 'Ementa criada com sucesso'});
    }
}

exports.listarRefeicoesEmenta= async function (req, res){
    const result= await EmentaService.listarRefeicoesEmenta(req.params);

    if(!result){
        res.status(404).send('Erro ao listar ementa');
    } else{
        res.status(201).json(result);
    }
}


exports.deleteEmentaById = async function (req, res) {
    const { id } = req.params;
    const result = await EmentaService.deleteEmentaById(id);

    if (result) {
        res.status(200).json({ message: 'Ementa apagada com sucesso' });
    } else {
        res.status(400).json({ error: 'Ementa não encontrada ou erro ao apagar' });
    }
};


exports.deleteAllEmenta = async function (req, res) {
    const result = await EmentaService.deleteAllEmenta();

    if (result) {
        res.status(200).json({ message: 'Todos as ementas foram apagadas com sucesso' });
    } else {
        res.status(500).json({ error: 'Erro ao apagar todas as ementas' });
    }
};
