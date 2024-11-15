var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');

router.post('/', clienteController.createCliente);
router.patch('/:id/deposit', clienteController.deposit)
router.get('/', clienteController.getClientes);

module.exports = router;