import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']

})
export class AppComponent {
  
  userId: number;
  constructor(private httpClient: HttpClient) {

  }

  sendData() {
    this.httpClient.get("http://localhost:65179/user?userId=" + this.userId + "&sendAllClients=false").subscribe((response: any) => {
      console.log("data sent");
    });
  }

  sendDataAllClients() {
    this.httpClient.get("http://localhost:65179/user?userId=&sendAllClients=true").subscribe((response: any) => {
      console.log("data sent");
    });
  }
}