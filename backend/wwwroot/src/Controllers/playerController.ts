import axios from "axios";

export default class PlayerController {
  public static url: string = "http://localhost:5000/";

  public static GetUsers() {
    return axios.get(this.url +"api/players");
  }

  public static GetUser(email: string) {
    axios.get(this.url + "api/players/" + email)
  }

  public static CreateUser(userEmail: string, userPass: string): object {
    return axios.post(this.url + "api/players", {
      Email: userEmail,
      Password: userPass
    });
  }

  public static EditUser(userId: string, userEmail: string, userPass: string) {
    return axios.put(this.url + "api/players", {
      ID: userId,
      Email: userEmail,
      Password: userPass
    });
  }

  public static DeleteUser(id: string) {
    return axios.delete(this.url + "api/users/" + id);
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
