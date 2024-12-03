const EncomendaService = require("../services/EncomendaService");


exports.createEncomenda= async function(req, res){
    try{
        const result= await EncomendaService.createEncomenda(req.body.ementaId, req.params.nif);

        if(!result){
            res.status(404).send('Erro ao criar encomenda');
        } else{
            res.status(201).json('Encomenda efetuada com sucesso');
        }
    }catch(err){
        console.error('Error ao criar encomenda:', err.message);
        res.status(500).json({ error: err.message }); 
    }
}

exports.getEncomendas = async function(req, res) {
    try {
        const result = await EncomendaService.getEncomendas();

        if (!result) {
            res.status(404).send('As encomendas não foram encontradas.');
        } else {
            res.status(200).json(result);
        }
    }catch(err){
        console.error('Error ao criar encomenda:', err.message);
        res.status(500).json({ error: err.message });
    }
}

exports.getEncomendaById = async function(req, res) {
    try{
    const result = await EncomendaService.getEncomendaById(req.params.id);

    if (!result) {
        res.status(404).send('A encomenda não foi encontrada.');
    } else {
        res.status(200).json(result);
    }
    }catch(err){
        console.error('Error ao criar encomenda:', err.message);
        res.status(500).json({ error: err.message });
    }
}

exports.getEncomendasByClienteNIF = async function (req, res) {
    try {
        const encomendas = await EncomendaService.getEncomendasByClienteNIF(req.params.nif);

        if (encomendas.length === 0) {
            return res.status(404).json({ message: "Nenhuma encomenda encontrada para este cliente." });
        }

        return res.status(200).json(encomendas);
    } catch (err) {
        res.status(500).json({ message: "Erro ao listar encomendas do cliente." });
    }
};

exports.getPratosComClientes = async function (req, res) {
    try {
        const pratosComClientes = await EncomendaService.getPratosComClientes();

        return res.status(200).json(pratosComClientes);
    } catch (err) {
        console.error("Erro no controller ao buscar pratos com clientes:", err.message);
        res.status(500).json({ message: "Erro ao buscar pratos com clientes." });
    }
};

exports.deleteEncomenda = async function(req, res) {
    try {
    const result = await EncomendaService.deleteEncomenda(req.params.id);

    if (!result) {
        res.status(400).send('Erro ao apagar encomenda.');
    } else {
        res.status(200).json('Encomenda apagada com sucesso.');
    }
    }catch(err){
        console.error('Error ao criar encomenda:', err.message);
        res.status(500).json({ error: err.message });
    }
}