import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from 'src/app/shared/appointment.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {



  constructor(public authService:AuthService,private router: Router, public appoiService: AppointmentService, public route: ActivatedRoute,
    private toasterService: ToastrService ) { }

  today = new Date().toLocaleDateString();


  ngOnInit(): void {

    this.appoiService.bindCmdDoctor();
    this.appoiService.bindCmdPatient();
    console.log(this.today);
    this.appoiService.formData1.IsActive=true;
    this.appoiService.formData1.PatientName=null;
    this.appoiService.formData1.DoctorName=null;
    //this.appoiService.formData1.DateofAppointment=this.today;
  }
  logOut(){
    this.authService.logOut();      
  }
  disableDate(){

    return false;

  }
  onSubmit(form): void {
    console.log(form.value);
    let addId = this.appoiService.formData1.AppointmentId;
    //insert

    if (addId == 0 || addId == null) {
      this.insertAppointment(form);
      //window.location.reload();

    }
  }

  //clear all content at initialisation

  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //insertAppontment
  insertAppointment(form?: NgForm) {
    console.log("inserting appointment...")
    this.appoiService.insertAppointment(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        this.router.navigate(['payment', result]);
        this.toasterService.success('Appointment created successfully');

      }
    );
    //window.location.reload();
  }

}



