var express = require('express');
var app = express();

// Persistence
var mongoose = require('mongoose');
mongoose.set('strictQuery', true);
// mongoose.connect('connection string');

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
