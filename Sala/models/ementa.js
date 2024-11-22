var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var EmentaSchema = new Schema({
    id : Schema.Types.ObjectId,
    prato:{
        id: { type: Number, required: true },
        nome: { type: String, required: true }
    },
    refeicaoId: {type: Number, required: true},
    preco: {type: Number, default: 0},
    criadoEm: { type: Date, default: Date.now }
});

module.exports = mongoose.model('Ementa', EmentaSchema);