var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');
const ementaController = require("../controllers/ementaController");


router.get('/clientes/:nif', clienteController.getClienteByNIF);  // Specific client by NIF
router.get('/clientes', clienteController.getClientes);  // All clients or general request
router.post('/clientes', clienteController.createCliente);
router.patch('/clientes/:nif/deposit', clienteController.deposit);
router.get('/clientes/:nif/saldo', clienteController.getClienteSaldo);
router.delete('/clientes/:nif', clienteController.deleteClienteByNIF); 
router.delete('/clientes', clienteController.deleteAllClientes); 
router.post("/ementa", ementaController.createEmenta);
router.get("/ementa/:refeicaoId", ementaController.listarRefeicoesEmenta);




module.exports = router;
