const EmentaService = require('../services/ementaService');

exports.createEmenta= async function (req, res){
    try{
    const result = await EmentaService.createEmenta(req.body);

    if(!result){
        res.status(404).send('Erro ao criar ementa');
    } else{
        res.status(201).json({message: 'Ementa criada com sucesso'});
    }
}catch(err){
    console.error('Error ao criar ementa:', err.message);
    res.status(500).json({ error: err.message });
}
}

exports.getEmentas = async function (req, res) {
    try{
    const result = await EmentaService.getEmentas();
    
    if(!result){
        res.status(404).send('Erro ao listar ementas');
    } else{
        res.status(200).json(result);
    }
}catch(err){
    console.error('Error a ir buscar todas as encomendas:', err.message);
    res.status(500).json({ error: err.message });
}
}

exports.getEmentaById = async function (req,res) {
    try{

    const result = await EmentaService.getEmentaById(req.params.id);

    if(!result){
        res.status(404).send('A ementa não foi encontrada');
    } else{
        res.status(200).json(result);
    }
}catch(err){
    console.error('Error a ir buscar ementa pelo id:', err.message);
    res.status(500).json({ error: err.message });
}
}

exports.getEmentaByRefeicao= async function (req, res){
    try{
    const result= await EmentaService.getEmentaByRefeicao(req.params);

    if(!result){
        res.status(404).send('Erro ao listar ementa');
    } else{
        res.status(201).json(result);
    }
}catch(err){
    console.error('Error a ir buscar ementa pela refeição:', err.message);
    res.status(500).json({ error: err.message });
}
}


exports.deleteEmentaById = async function (req, res) {
    try{
    const { id } = req.params;
    const result = await EmentaService.deleteEmentaById(id);

    if (result) {
        res.status(200).json({ message: 'Ementa apagada com sucesso' });
    } else {
        res.status(400).json({ error: 'Ementa não encontrada ou erro ao apagar' });
    }
}catch(err){
    console.error('Error ao apagar ementa pelo id:', err.message);
    res.status(500).json({ error: err.message });
}
};


exports.deleteAllEmenta = async function (req, res) {
    try{

    const result = await EmentaService.deleteAllEmenta();

    if (result) {
        res.status(200).json({ message: 'Todos as ementas foram apagadas com sucesso' });
    } else {
        res.status(500).json({ error: 'Erro ao apagar todas as ementas' });
    }
}catch(err){
    console.error('Error ao apagar todas as ementa:', err.message);
    res.status(500).json({ error: err.message });
}
};
