"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/characterloaderhub").build();




connection.on("UpdateView", function (data) {

    
    document.getElementById("lastUpdateTime").innerHTML = data.time;

 
    var Parent = document.getElementsByTagName('tbody')[0];
    while (Parent.hasChildNodes()) {
        Parent.removeChild(Parent.firstChild);
    }

 

    for (var i in data.result) {
        var newRow = Parent.insertRow();
        var nameCell = newRow.insertCell();
        var imageCell = newRow.insertCell();

        var nametxt = document.createTextNode(data.result[i].name);
        var imgTxt = document.createElement('img');
        imgTxt.className = "rounded"
        imgTxt.src = data.result[i].image; 
        nameCell.appendChild(nametxt);
       imageCell.appendChild(imgTxt);

    }

});

connection.on("logerr", function (err) {
    console.error(err.toString());
});


connection.on("loginfo", function (data) {
    console.log(data.toString());
});

connection.on("updatetime", function (data) {
    document.getElementById("lastUpdateTime").innerHTML = data.time;
});

connection.start().then(function () {
    connection.invoke("Start").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}).catch(function (err) {
    return console.error(err.toString());
});