"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("selectedUser").value = user;
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var userId = document.getElementById("selectedUser").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke('SendMessageToGroup', userId, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});
if (document.getElementById("messageInput")) {
    document.getElementById("messageInput").value = "";
    document.getElementById("messageInput").focus();
}
