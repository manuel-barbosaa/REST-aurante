const webApiClient = require('axios').default;

exports.getEmenta = async function (id) {
    process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;   // Inibe a vericação dos certificados

    const cozinhaWebAPIURL = 'https://localhost:7291/api/Heroes/'

    const ementaCozinha = await webApiClient.get(cozinhaWebAPIURL + id);
   
    return ementaCozinha.data;
}
