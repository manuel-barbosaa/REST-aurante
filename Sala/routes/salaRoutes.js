var express = require('express');
var router = express.Router();

const clienteController = require('../controllers/clienteController');
const ementaController = require("../controllers/ementaController");
const encomendaController = require('../controllers/encomendaController');



router.get('/clientes/:nif', clienteController.getClienteByNIF);  // Specific client by NIF
router.get('/clientes', clienteController.getClientes);  // All clients or general request
router.post('/clientes', clienteController.createCliente);
router.patch('/clientes/:nif/deposit', clienteController.deposit);
router.get('/clientes/:nif/saldo', clienteController.getClienteSaldo);
router.delete('/clientes/:nif', clienteController.deleteClienteByNIF); 
router.delete('/clientes', clienteController.deleteAllClientes); 
router.post("/ementa", ementaController.createEmenta);
router.get("/ementa/:id", ementaController.getEmentaById);
router.get("/ementas", ementaController.getEmentas);
router.get("/ementa/refeicao/:refeicaoId", ementaController.getEmentaByRefeicao);
router.delete('/ementa/:id', ementaController.deleteEmentaById); 
router.delete('/ementa', ementaController.deleteAllEmenta);
router.post('/encomenda/:nif', encomendaController.createEncomenda);
router.get('/encomendas/cliente/:nif', encomendaController.getEncomendasByClienteNIF);
router.get('/encomenda/:id', encomendaController.getEncomendaById);
router.get('/encomendas', encomendaController.getEncomendas);
router.get('/encomendas/pratos', encomendaController.getPratosComClientes);
router.delete('/encomendas/:id', encomendaController.deleteEncomenda);

module.exports = router;
