import axios from "axios";

class PlayerController {
  public GetUsers() {
    return axios.get("/api/players");
  }

  public GetUser(id: number) {
    axios.get("/api/players/" + id);
  }

  public CreateUser(userEmail: string, userPass: string) {
    return axios.post("api/players", {
      Email: userEmail,
      Password: userPass
    });
  }

  public EditUser(userId: string, userEmail: string, userPass: string) {
    return axios.put("api/players", {
      ID: userId,
      Email: userEmail,
      Password: userPass
    });
  }

  public DeleteUser(id: string) {
    return axios.delete("api/users/" + id);
  }

  //  $("form").submit(function (e) {
  //    e.preventDefault();
  //    var id = this.elements["id"].value;
  //    var email = this.elements["Email"].value;
  //    var password = this.elements["Password"].value;
  //    if (id == 0)
  //        CreateUser(email, password);
  //    else
  //        EditUser(id, email, password);
  //  });
}

export default PlayerController;
