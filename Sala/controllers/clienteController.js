const ClienteModel = require('../models/cliente');

const ClienteService = require('../services/clienteService');

exports.getClientes = async function (req, res) {
    try{
    const result = await ClienteService.getClientes();
    res.status(200).json(result);
    }catch(err){
    console.error('Error a ir buscar os clientes:', err.message);
    res.status(500).json({ error: err.message });
}
}

exports.createCliente= async function (req, res){
    try{
        const result = await ClienteService.createCliente(req.body);

        if(!result){
            res.status(404).send('Erro ao criar cliente');
    } else{
            res.status(201).json({message: 'Cliente criado com sucesso'});
    }
    }catch(err){
    console.error('Error ao criar cliente:', err.message);
    res.status(500).json({ error: err.message });
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
    console.error('Erro a ir buscar o cliente pelo NIF:', err);
    res.status(500).json({ error: err.message });
}
};

exports.getClienteSaldo = async function (req, res) {
    try{

    const result = await ClienteService.getClienteSaldo(req.params.nif);

    if (!result) {
        res.status(404).json({ error: 'Cliente não encontrado' });
    } else {
        res.status(200).json(result);
    }

}catch(err){
    console.error('Error ao ir buscar o saldo do cliente:', err.message);
    res.status(500).json({ error: err.message });
}
}

exports.deposit = async function (req, res) {
    try{
    const {nif} = req.params;
    const { quantia } = req.body;
    const result = await ClienteService.deposit(nif, parseFloat(quantia));

    if (result) {
        return res.status(200).json({ message: 'Depósito efetuado com sucesso' });
    } else {
        return res.status(400).json({ message: 'Falha ao efetuar depósito. O cliente não foi encontrado ou ocorreu um erro.' });
    }
}catch(err){
    console.error('Error ao fazer o depósito:', err.message);
    res.status(500).json({ error: err.message });
}
}




exports.deleteClienteByNIF = async function (req, res) {
    try{
    const { nif } = req.params;
    const result = await ClienteService.deleteClienteByNIF(nif);

    if (result) {
        res.status(200).json({ message: 'Cliente apagado com sucesso' });
    } else {
        res.status(400).json({ error: 'Cliente não encontrado ou erro ao apagar' });
    }


    }catch(err){
    console.error('Error ao apagar cliente pelo NIF:', err.message);
    res.status(500).json({ error: err.message });
}
};


exports.deleteAllClientes = async function (req, res) {
    try{


    const result = await ClienteService.deleteAllClientes();

    if (result) {
        res.status(200).json({ message: 'Todos os clientes foram apagados com sucesso' });
    } else {
        res.status(500).json({ error: 'Erro ao apagar todos os clientes' });
    }


}catch(err){
    console.error('Error ao apagar clientes:', err.message);
    res.status(500).json({ error: err.message });
}
};
