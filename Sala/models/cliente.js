// models/cliente.js
const mongoose = require('mongoose');

const clienteSchema = new mongoose.Schema({
    nome: { type: String, required: true },
    nif: { type: String, required: true, unique: true },
    email: { type: String, required: true, unique: true },
    saldo: { type: Number, default: 0 },
});

module.exports = mongoose.model('Cliente', clienteSchema);
