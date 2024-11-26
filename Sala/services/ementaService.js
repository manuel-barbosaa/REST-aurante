const webApiClient = require('axios').default;
const ementaRepository = require("../repositories/ementaRepository")

exports.getEmentaCozinha = async function (id) {
    process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;

    const cozinhaWebAPIURL = 'http://localhost:5230/api/Ementa/'

    const ementaCozinha = await webApiClient.get(cozinhaWebAPIURL + id);
   
    return ementaCozinha.data;
}

exports.createEmenta = async function (ementaDTO){
    const ementaId = ementaDTO.ementaId;
    const refeicaoId = ementaDTO.refeicaoId;
    const preco = ementaDTO.preco;

    const ementaCozinha = await exports.getEmentaCozinha(ementaId);

    if(ementaCozinha == null) {
        throw new error("A ementa não foi encontrada na cozinha.");
    }

    const refeicao = ementaCozinha.refeicoes.filter(refeicao => refeicao.id === refeicaoId)[0];

    if(refeicao == null) {
        throw new error("A refeicão não foi encontrado na ementa da cozinha.")
    } 
    
    const prato = {
        id: refeicao.prato.id,
        nome: refeicao.prato.nome
    };
    


    return await ementaRepository.createEmenta({
        prato: prato,
        refeicaoId: refeicaoId,
        preco: preco
    });
}

exports.getEmentas = async function() {
    const allEmentas = await ementaRepository.getEmentas();
    iList = new Array();
    allEmentas.forEach(
        (i) => {
            iList.push({
                'id': i._id,
                'prato':    i.prato,
                'refeicaoId': i.refeicaoId,
                'preco': i.preco
            })
        }
    );
    return iList
}

exports.getEmentaById = async function(id) {
    return await ementaRepository.getEmentaById(id);
}

exports.getEmentaByRefeicao = async function ({ refeicaoId }) {
    return await ementaRepository.getEmentaByRefeicaoId(refeicaoId);
}

exports.deleteEmentaById = async function (id) {
    return await ementaRepository.deleteEmentaById(id);
};

exports.deleteAllEmenta = async function () {
    return await ementaRepository.deleteAllEmenta();
};
