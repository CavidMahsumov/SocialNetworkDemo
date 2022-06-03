

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.




connection.start();


connection.on("ReceiveMessage", function (message) {
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

document.getElementById("sendbtn").addEventListener("click", function (event) {
    console.log("Salam");
    var message = document.getElementById("messageInput").value;
    console.log(message);
    connection.invoke("SendMessage", message);
    event.preventDefault();
},






//document.getElementById("sendbtn").addEventListener("click", function (event) {
//    console.log("Salam");
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message);
//    })
//    event.preventDefault();
    function loadcauhoi(data) {
        console.log("Sakam");
        $.ajax({
            dataType: "Html",
            type: "POST",
            url: '@Url.Action("AddLike","PostController")',
            data: { model: data },
            success: function (a) {
                // Replace the div's content with the page method's return.
                alert("success");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown)
            }
        });
    }