const express = require('express');
const router = express.Router();
const clienteController = require('../Controller/clienteController');

// Rota para validar se o cliente existe pelo NIF
router.get('/cliente/validar/:nif', async (req, res) => {
    try {
        const cliente = await clienteController.validarClientePorNif(req.params.nif);
        res.status(200).json(cliente);
    } catch (err) {
        res.status(404).json({ error: err.message });
    }
});

// Rota para obter as informações básicas do cliente
router.get('/cliente/informacoes/:nif', async (req, res) => {
    try {
        const cliente = await clienteController.obterInformacoesCliente(req.params.nif);
        res.status(200).json(cliente);
    } catch (err) {
        res.status(404).json({ error: err.message });
    }
});

module.exports = router;
