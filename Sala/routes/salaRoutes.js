var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');

router.post('/clientes', clienteController.createCliente);
router.patch('/clientes/:nif/deposit', clienteController.deposit)
router.get('/clientes/', clienteController.getClientes);
router.get('clientes/:nif', clienteController.getClienteByNIF);
router.get('clientes/:nif/saldo', clienteController.getClienteSaldo);

module.exports = router;