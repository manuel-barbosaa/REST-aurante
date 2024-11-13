// routes/admin.js
const express = require('express');
const Cliente = require('../models/cliente');
const router = express.Router();

// Endpoint para registar um novo cliente (US001)
router.post('/clientes', async (req, res) => {
    try {
        const { nome, nif, email } = req.body;
        const novoCliente = new Cliente({ nome, nif, email, saldo: 0 });
        await novoCliente.save();
        res.status(201).json(novoCliente);
    } catch (error) {
        res.status(400).json({ message: 'Erro ao registar cliente', error });
    }
});