
const ementaRepository= require("../repositories/ementaRepository")
const clienteRepository= require("../repositories/clienteRepository")


exports.createEncomenda = async function(ementaId, clienteNif){
    
    const ementa= ementaRepository.getEmentaById(ementaId);
    const prato= ementa.prato.nome;
    const valor= ementa.preco; 
    const cliente= clienteRepository.getEmentaByNIF(clienteNif);

    if(cliente.saldo< valor){
       return false;
    
    }
    return await ementaRepository.createEncomenda({
        cliente: cliente,
        data: Date.now,
        prato: prato,
        valor: valor
        
    });

} 