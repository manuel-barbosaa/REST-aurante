var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');

router.post('/', clienteController.createCliente);

module.exports = router;