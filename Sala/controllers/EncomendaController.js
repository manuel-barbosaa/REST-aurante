const EncomendaService = require("../services/EncomendaService");


exports.createEncomenda= async function(req, res){
    const result= await EncomendaService.createEncomenda(req.body.ementaId, req.params.nif);

    if(!result){
        res.status(404).send('Erro ao criar encomenda');
    } else{
        res.status(201).json({message: 'Encomenda criada com sucesso'});
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
        console.error("Erro no controller:", err.message);
        res.status(500).json({ message: "Erro ao listar encomendas do cliente." });
    }
};

exports.getPratosComClientes = async function (req, res) {
    try {
        const pratosComClientes = await EncomendaService.getClientesByPrato();

        return res.status(200).json(pratosComClientes);
    } catch (err) {
        console.error("Erro no controller ao buscar pratos com clientes:", err.message);
        res.status(500).json({ message: "Erro ao buscar pratos com clientes." });
    }
};