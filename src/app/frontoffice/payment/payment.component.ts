import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {PaymentService} from "src/app/shared/payment.service"
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  AId:number;

  constructor(public authService:AuthService,
    private router: Router,
    public paymentService: PaymentService,
    private route: ActivatedRoute,
    private toasterService: ToastrService
  ) { }

  ngOnInit(): void {
    this.AId = this.route.snapshot.params['AId'];

    this.paymentService.paymentData.PaymentId = this.AId;
    this.paymentService.paymentData.IsActive=true;

    if (this.AId != 0 || this.AId != null) {
      //getEmployee
      this.paymentService.paymentData.AppointmentId = this.AId;
    }
  }

   //Clear all contents at loading
   resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }
  logOut(){
    this.authService.logOut();      
  }
  disableDate(){

    return false;

  } 

  onSubmit(form?: NgForm){
    console.log("payment inserting to db");
    this.insertPayment(form);
    console.log("INitialization");
  }

  insertPayment(form: NgForm){
    this.paymentService.insertPayment(form.value).subscribe(
      (result) => console.log(result)
    )
    this.toasterService.success('Payment Receipt created successfully');
    this.resetForm(form);
    this.router.navigate(['frontoffice']);
  }

}
