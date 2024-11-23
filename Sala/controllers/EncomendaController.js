


exports.createEncomenda= async function(req, res){
    const result= await EncomendaService.createEncomenda(req.body, req.params);

    if(!result){
        res.status(404).send('Erro ao criar encomenda');
    } else{
        res.status(201).json({message: 'Encomenda criada com sucesso'});
    }
}