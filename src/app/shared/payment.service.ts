import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Payment } from 'src/app/shared/payment';
import { environment } from "src/environments/environment"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  paymentData: Payment = new Payment();
  payment: Payment[];

  constructor(
    private httpClient: HttpClient
  ) { }

  insertPayment(payment: Payment): Observable<any> {
    return this.httpClient.post(environment.apiUrl+ "/api/payment/AddPayment", payment);
  }

  getpayment(){
    this.httpClient.get(environment.apiUrl+ "/api/payment/GetPayments").toPromise()
    .then(
      result => this.payment = result as Payment[]
    )
    console.log(this.payment);
  }

}
