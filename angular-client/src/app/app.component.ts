import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';
import { CustomerService } from './services/customer.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Customer } from './models/customer';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  private hubConnection: HubConnection | undefined;
  private customer : Customer;
  customerForm: FormGroup;

  constructor(
    private toastr: ToastrService, 
    private customerService: CustomerService,
    private formBuilder: FormBuilder) { }

 
  ngOnInit(): void {

    this.customerForm = this.formBuilder.group({
      name: [null, Validators.required],
    });

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

  save() : void {
    this.customer = JSON.parse(JSON.stringify(this.customerForm.value));
    this.customerService.insert(this.customer)
        .subscribe(r=> {
          this.customerForm.get("name").setValue("");
          console.log(JSON.parse(JSON.stringify(r)));
        });
  }
}