var express = require('express');
var app = express();
var fs = require("fs");

const bodyParser = require('body-parser'); 
app.use(bodyParser.json()); 


 var ToDos=["Sample ToDo1","Sample ToDo2", "Sample ToDo3"];

//Gets the entire ToDo list

app.get('/todos', function (req, res) {
        console.log( "All ToDos displayed" );
        return res.json(ToDos);
 });

//Adds a ToDo

app.post('/insert', function (req, res) {
   ToDos.push(req.body.todo);
   return res.json(ToDos);
});
 
//Updates a ToDo

app.put('/update', function (req, res) {
    console.log(req);
    var t = req.body.old;
    var index = ToDos.indexOf(t);
    if(index == -1){
        res.send("ToDo not found");
    }
    else{
        ToDos.splice(index,1,req.body.new);
        
        res.send("ToDo updated"); 
    }
});

//Deletes a ToDo
app.delete('/delete', function (req, res) {
    var t = req.body.todo;
    var index = ToDos.indexOf(t);
    if(index == -1){
        res.send("ToDo not found");
    }
    else{
        ToDos.splice(index,1);
        
        res.send("ToDo deleted"); 
    }
    }) 
 
//Listening at localhost server

var server = app.listen(3000, function () {
    var port = server.address().port;
    console.log("MyApp listening at http://localhost:%s", port)
 })