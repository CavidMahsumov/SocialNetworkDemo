

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var content = `                                <div class="message-item">
                                    <div class="message-user">
                                        <figure class="avatar">
                                            <img src="~/images/user-9.png" alt="image">
                                        </figure>
                                        <div>
                                            <h5>Byrom Guittet</h5>
                                            <div class="time">01:35 PM</div>
                                        </div>
                                    </div>
                                    <div class="message-wrap">${message}</div>
                                </div>`
    document.getElementById("mid").appendChild(content);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
});




connection.on("Connect", function (info) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.innerHTML = `<span style='color:green;'>${info}</span>`;
});


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendbtn").addEventListener("click", function (event) {
    console.log("Salam");
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});