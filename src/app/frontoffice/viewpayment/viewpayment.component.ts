import { Component, OnInit } from '@angular/core';
import { PaymentService } from 'src/app/shared/payment.service';

@Component({
  selector: 'app-viewpayment',
  templateUrl: './viewpayment.component.html',
  styleUrls: ['./viewpayment.component.css']
})
export class ViewpaymentComponent implements OnInit {

  filter: string;
  page: number=1;

  constructor(
    public paymentService: PaymentService
  ) { }

  ngOnInit(): void {
    this.paymentService.getpayment();
    console.log(this.paymentService.payment);
  }

}
