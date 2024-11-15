const ClienteModel = require('../models/cliente');

const ClienteService = require('../services/clienteService');

exports.getClientes = async function (req, res) {
    const result = await ClienteService.getClientes();
    res.status(200).json(result);
}

exports.createCliente= async function (req, res){
    const result = await ClienteService.createCliente(req.body);

    if(!result){
        res.status(400).send('Erro ao criar cliente');
    } else{
        res.status(201).json({message: 'Cliente criado com sucesso'});
    }
}

exports.deposit = async function (req, res) {
    const { id } = req.params;
    const { quantia } = req.body;
    const result = await ClienteService.deposit(id, parseFloat(quantia));

    if (result) {
        return res.status(200).json({ message: 'Depósito efetuado com sucesso' });
    } else {
        return res.status(400).json({ message: 'Falha ao efetuar depósito. O cliente não foi encontrado ou ocorreu um erro.' });
    }
}