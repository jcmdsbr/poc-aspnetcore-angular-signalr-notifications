import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerUrl: string;
  constructor(private http: HttpClient) {
    this.customerUrl = `${environment.apiBaseUrl}/customers`;
  }

  public insert(customer:Customer): Observable<Object> {
    return this.http.post(this.customerUrl, customer);
  }
}
