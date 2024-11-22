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

    // const prato = refeicao.prato.nome;
    
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



exports.listarRefeicoesEmenta = async function ({ refeicaoId }) {
    try {
        //ver se o id é um número válido
        if (!refeicaoId || isNaN(Number(refeicaoId))) {
            throw new Error('O ID da refeição fornecido é inválido.');
        }

        return await ementaRepository.getEmentaByRefeicaoId(refeicaoId);
    } catch (err) {
        throw new Error(`Erro a listar ementa do id fornecido: ${err.message}`);
    }
}

exports.deleteEmentaById = async function (id) {
    return await ementaRepository.deleteEmentaById(id);
};

exports.deleteAllEmenta = async function () {
    return await ementaRepository.deleteAllEmenta();
};
