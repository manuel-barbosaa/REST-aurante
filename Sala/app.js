var express = require('express');
var app = express();

// Persistence
var mongoose = require('mongoose');
mongoose.set('strictQuery', true);
mongoose.connect('mongodb+srv://<username>:<password>@cluster0.mongodb.net/?retryWrites=true&w=majority', {
    useNewUrlParser: true,
    useUnifiedTopology: true,
})
.then(() => console.log('Conectado ao MongoDB'))
.catch(error => console.log('Erro ao conectar ao MongoDB:', error));


// Parser 
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());

// Middleware
var mWare = require('./middleware');
app.use(mWare);

var port = 8080;
app.listen(port);
console.log('---------------' + '\nUsing port ' + port + '\n---------------');

module.exports = app;

const adminRoutes = require('./routes/admin');
app.use('/api/admin', adminRoutes);

