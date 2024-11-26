var mongoose = require("mongoose");
var Schema = mongoose.Schema;


var EncomendaSchema = new Schema({
    id : Schema.Types.ObjectId,
    cliente: { type: String, required: true },
    data: { type: Date, default: Date.now },
    prato: { type: String, required: true },
    valor: { type: Number, required: true }
});

module.exports = mongoose.model('Encomenda', EncomendaSchema);
