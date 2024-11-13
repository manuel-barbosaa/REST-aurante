const ClienteModel = require('../models/cliente');

const ClienteService = require('../services/clienteService');

exports.creatCliente= async function (req, res){
    const result = await ClienteService.createCliente(req.body);

    if(!result){
        res.status(400).send('Erro ao criar cliente');
    } else{
        res.status(201).json({message: 'Cliente criado com sucesso'});
    }
}
