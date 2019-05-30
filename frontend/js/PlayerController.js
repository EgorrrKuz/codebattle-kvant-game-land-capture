// Player list
function GetUsers() {
    $.ajax({
        url: url,
        type: 'GET',
        contentType: "application/json",
    });
}
// One player
function GetUser(id) {
    $.ajax({
        url: '/api/players/' + id,
        type: 'GET',
        contentType: "application/json",
    });
}

// Register
function CreateUser(userEmail, userPass) {
     $.ajax({
         url: url,
         contentType: "application/json",
         method: "POST",
         data: JSON.stringify({
             Email : userEmail,
             Password : userPass,
         }),
     })
}

// Edit player
function EditUser(userId, userEmail, userPass) {
    $.ajax({
        url: url,
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify({
            ID: userId,
            Email: userEmail,
            Password: userPass
        }),
    })
}

// Delete player
function DeleteUser(id) {
    $.ajax({
        url: url + id,
        contentType: "application/json",
        method: "DELETE",
    })
}

// Form submit
$("form").submit(function (e) {
    e.preventDefault();
    var id = this.elements["id"].value;
    var email = this.elements["Email"].value;
    var password = this.elements["Password"].value;
    if (id == 0)
        CreateUser(email, password);
    else
        EditUser(id, email, password);
});
