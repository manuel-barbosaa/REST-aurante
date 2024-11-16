const webApiClient = require('axios').default;
const ementaRepository = require("../repositories/ementaRepository")

exports.getEmentaCozinha = async function (id) {
    process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;   // Inibe a vericação dos certificados

    const cozinhaWebAPIURL = 'http://localhost:5230/api/Ementa/'

    const ementaCozinha = await webApiClient.get(cozinhaWebAPIURL + id);
   
    return ementaCozinha.data;
}

exports.createEmenta = async function (ementaDTO){
    const ementaId = ementaDTO.ementaId;
    const refeicaoId = ementaDTO.refeicaoId;
    const preco = ementaDTO.preco;

    const ementaCozinha = await exports.getEmentaCozinha(ementaId);

    const refeicao = ementaCozinha.refeicoes.filter(refeicao => refeicao.id === refeicaoId)[0];
    
    const prato = refeicao.prato;
    console.log(prato);
    console.log(refeicao);
    console.log(ementaCozinha);

    return await ementaRepository.createEmenta({
        prato: prato,
        refeicao: refeicaoId,
        preco: preco
    });
}
