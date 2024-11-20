var Schema = mongoose.Schema;
var mongoose = require("mongoose");


var EncomendaSchema = new Schema({
    cliente: { type: Schema.Types.ObjectId, ref: 'Cliente', required: true },
    data: { type: Date, default: Date.now },
    prato: { type: String, required: true },
    valor: { type: Number, required: true }
});

module.exports = mongoose.model('Encomenda', EncomendaSchema);
