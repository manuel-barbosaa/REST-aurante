var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');

router.post('/clientes', clienteController.createCliente);
router.patch('/clientes/:id/deposit', clienteController.deposit)
router.get('/clientes/', clienteController.getClientes);
router.get('/:nif', clienteController.getClienteByNIF);

module.exports = router;