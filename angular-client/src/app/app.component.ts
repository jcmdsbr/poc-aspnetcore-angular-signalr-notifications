import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  private hubConnection: HubConnection | undefined;

  msgs: string[] = [];

  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
    let builder = new HubConnectionBuilder();
    
    this.hubConnection =
     builder.withUrl('https://localhost:5001/notifications').build();

    this.hubConnection
    .start()
    .then(() => console.log('Connection started!'))
    .catch(err => console.log(err));

    this.hubConnection.on('Notify', (message: string) => {
      this.toastr.success(message);
    }); 
  }
}