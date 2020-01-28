import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']

})
export class AppComponent implements OnInit {
  array: string[] = [];

  ngOnInit(): void {
    this.array = [];

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl("http://localhost:65179/users?userId=1")
      .build();

    connection.start().then(function () {
      console.log('Client 1 connected!');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    connection.on("NotifyUser", (response: any) => {
      this.array.push('Data received: ' + response);
      console.log(response);
    });
  }
}