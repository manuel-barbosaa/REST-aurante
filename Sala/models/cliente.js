var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var ClienteSchema = new Schema({
    id: Schema.Types.ObjectId,
    nome: String,
    nif: String,
    email: String,
    balance: {type: Number, default: 0},
});

module.exports = mongoose.model('Cliente', ClienteSchema);