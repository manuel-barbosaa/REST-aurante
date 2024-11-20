const ClienteModel = require('../models/cliente');

const ClienteService = require('../services/clienteService');

exports.getClientes = async function (req, res) {
    const result = await ClienteService.getClientes();
    res.status(200).json(result);
}

exports.createCliente= async function (req, res){
    const result = await ClienteService.createCliente(req.body);

    if(!result){
        res.status(404).send('Erro ao criar cliente');
    } else{
        res.status(201).json({message: 'Cliente criado com sucesso'});
    }
}

exports.getClienteByNIF = async function (req, res) {
    console.log("NIF recebido:", req.params.nif); // Log do parâmetro
    try{
    const result = await ClienteService.getClienteByNIF(req.params.nif);

    if (!result) {
        res.status(404).json({ error: 'Cliente não encontrado' });
    } else {
        res.status(200).json(result);
    }
} catch (err) {
    console.error('Erro no controller:', err);
    res.status(500).json({ error: 'Erro interno' });
}
};

exports.getClienteSaldo = async function (req, res) {
    const result = await ClienteService.getClienteSaldo(req.params.nif);

    if (!result) {
        res.status(404).json({ error: 'Cliente não encontrado' });
    } else {
        res.status(200).json(result);
    }
}

exports.deposit = async function (req, res) {
    const {nif} = req.params;
    const { quantia } = req.body;
    const result = await ClienteService.deposit(nif, parseFloat(quantia));

    if (result) {
        return res.status(200).json({ message: 'Depósito efetuado com sucesso' });
    } else {
        return res.status(400).json({ message: 'Falha ao efetuar depósito. O cliente não foi encontrado ou ocorreu um erro.' });
    }
}



exports.deleteClienteByNIF = async function (req, res) {
    const { nif } = req.params;
    const result = await ClienteService.deleteClienteByNIF(nif);

    if (result) {
        res.status(200).json({ message: 'Cliente apagado com sucesso' });
    } else {
        res.status(400).json({ error: 'Cliente não encontrado ou erro ao apagar' });
    }
};


exports.deleteAllClientes = async function (req, res) {
    const result = await ClienteService.deleteAllClientes();

    if (result) {
        res.status(200).json({ message: 'Todos os clientes foram apagados com sucesso' });
    } else {
        res.status(500).json({ error: 'Erro ao apagar todos os clientes' });
    }
};
