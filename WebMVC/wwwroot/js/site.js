// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// SignalR Client Configuration
var connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:7075/DataSignalRChanel") // Host Hub
  .build();

connection.on("load", function () {
  //   location.href = "/Accounts/Index"; // hoặc
  location.reload();
});

connection
  .start()
  .then(() => console.log("SignalR connected from MVC"))
  .catch((err) => console.error("Lỗi kết nối SignalR:", err.toString()));
