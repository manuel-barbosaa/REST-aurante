var express = require('express');
var app = express();

// Middleware para CORS
var cors = require('cors');

// Configuração do CORS para permitir acesso da porta 4200 (Angular)
app.use(cors({
    origin: 'http://localhost:4200',  // Permite apenas o frontend do Angular
    methods: ['GET', 'POST', 'PUT', 'DELETE'],  // Métodos permitidos
    allowedHeaders: ['Content-Type', 'Authorization']  // Cabeçalhos permitidos
}));

// Persistence================================================================
var mongoose = require('mongoose');
mongoose.set('strictQuery', true);
mongoose.connect('mongodb+srv://admin:sinf2@restaurante.wnyvm.mongodb.net/?retryWrites=true&w=majority&appName=RESTaurante', {
    useNewUrlParser: true,
    useUnifiedTopology: true,
})
    .then(() => console.log('Conectado ao MongoDB'))
    .catch(error => console.log('Erro ao conectar ao MongoDB:', error));

// Parser=====================================================================
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());

// Middleware=================================================================
var mWare = require('./middleware');
app.use(mWare);

// Routing ===============================================
var salaRouter = require('./routes/salaRoutes');
app.use('/api', salaRouter);

var port = 8080;
app.listen(port, () => {
    console.log('---------------' + '\nUsing port ' + port + '\n---------------');
});

module.exports = app;