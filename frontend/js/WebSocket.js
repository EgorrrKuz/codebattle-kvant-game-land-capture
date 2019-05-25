import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import '@fortawesome/fontawesome-free/css/all.css'
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'
 
const connection = new HubConnectionBuilder()
  .withUrl('http://localhost:8080/command')
  .configureLogging(LogLevel.Information)
  .build()
 
connection.start()
 
connection.start()

hubConnection.on('UpFront', async function (x, y, email) {
    // Draw bot
    // Canavas

    var canvas = document.getElementById("myCanvas"), 
    context = canvas.getContext("2d");
    context.beginPath();
    context.rect(x, y, 2, 2);
    context.closePath();
    context.strokeStyle = "red"; // TODO: Generate on Back-end
    context.stroke();
});
hubConnection.on('DownFront', async function () {
    // Draw bot
    // Canavas
});
hubConnection.on('LeftFront', async function () {
    // Draw bot
    // Canavas
});
hubConnection.on('RightFront', async function () {
    // Draw bot
    // Canavas
});
hubConnection.on('AddPointFront', async function () {
    // Draw point
    // Canavas
});
hubConnection.on('GetCloseArea', async function () {
    // List points - close area
    // Canavas
});

hubConnection.start().then(function () {
    console.log("connected");
});
