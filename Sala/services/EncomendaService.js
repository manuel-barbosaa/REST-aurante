
const ementaRepository= require("../repositories/ementaRepository")
const clienteRepository= require("../repositories/clienteRepository")


exports.createEncomenda = async function(ementaId, clienteNif){
    
    const ementa= await ementaRepository.getEmentaById(ementaId);
    const prato= ementa.prato.nome;
    const valor= ementa.preco; 
    const cliente= await clienteRepository.getEmentaByNIF(clienteNif);

    if(cliente.saldo< valor){
       return false;
    
    }
    // Cria a encomenda
    const novaEncomenda = await ementaRepository.createEncomenda({
        cliente: cliente,
        data: Date.now(),
        prato: prato,
        valor: valor
    });

    const debito = -valor; // O valor é negativo para debitar
    await clienteRepository.updateSaldo(clienteNif, debito);


    return { success: true, encomenda: novaEncomenda };
};

