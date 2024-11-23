const EncomendaService = require("../services/EncomendaService");


exports.createEncomenda= async function(req, res){
    const result= await EncomendaService.createEncomenda(req.body.ementaId, req.params.nif);

    if(!result){
        res.status(404).send('Erro ao criar encomenda');
    } else{
        res.status(201).json({message: 'Encomenda criada com sucesso'});
    }
}


exports.listEncomendasCliente = async function (req, res) {
    const { nif } = req.params;

    try {
        const result = await EncomendaService.listEncomendasCliente(nif);

        if (!result || result.length === 0) {
            return res.status(404).json({ message: "Nenhuma encomenda encontrada para este cliente." });
        }

        res.status(200).json(result);
    } catch (error) {
        console.error("Erro ao listar encomendas do cliente:", error);
        res.status(500).json({ message: "Erro interno ao listar encomendas." });
    }
};