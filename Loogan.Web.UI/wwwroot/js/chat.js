"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
if (document.getElementById("sendButton")) {
    document.getElementById("sendButton").disabled = true;
}
connection.on("ReceiveMessage", function (user, message) {
    if (message == null || message == "" || message == undefined) {
        return;
    }
    $('#notification').prop('src', '/images/notification.png');
    $('#notification').css('cursor', 'pointer');
    if (!document.getElementById("selectedUser")) {
        sessionStorage.setItem("chatMessages", (user + "$" + message));
    }
    $('#notification').on('click', function () {
        window.location.href = '/ActivityStream/ActivityStream';
    });
    if (document.getElementById("selectedUser")) {
        var li = document.createElement("li");
        document.getElementById("selectedUser").value = user;
        document.getElementById("messagesList").appendChild(li);
        li.textContent = `${user} says ${message}`;
    }
});

connection.start().then(function () {
    if (document.getElementById("sendButton")) {
        document.getElementById("sendButton").disabled = false;
    }
}).catch(function (err) {
    return console.error(err.toString());
});

if (document.getElementById("sendButton")) {
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
}
if (document.getElementById("messageInput")) {
    document.getElementById("messageInput").value = "";
    document.getElementById("messageInput").focus();
}

$('#clearButton').on('click', function () {
    window.location.href = window.location.href;
});
