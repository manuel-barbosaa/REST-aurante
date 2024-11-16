var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');
const ementaController = require("../controllers/ementaController");

// Define the routes in the correct order
router.get('/clientes/:nif', clienteController.getClienteByNIF);  // Specific client by NIF
router.get('/clientes', clienteController.getClientes);  // All clients or general request
router.post('/clientes', clienteController.createCliente);
router.patch('/clientes/:nif/deposit', clienteController.deposit);
router.get('/clientes/:nif/saldo', clienteController.getClienteSaldo);
router.post("/ementa", ementaController.createEmenta);


module.exports = router;
