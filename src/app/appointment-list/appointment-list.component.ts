import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from '../shared/appointment.service';
import { PatientLog } from '../shared/patientlog';
import { DatePipe } from '@angular/common'
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {

  page: number = 1;
  today = new Date();
  DoctorId: number;

  role = localStorage.getItem('ACCESS_ROLE');

  constructor(public appservice: AppointmentService, public router: Router, public datepipe: DatePipe, public loginservice: AuthService) { }
  username: string;
  ngOnInit(): void {
    this.appservice.GetAppointmentbyVM();
    console.log(this.today);
    this.username = localStorage.getItem('userName');
    this.loginuser(this.username);
    //console.log(this.appservice.formData1.DateofAppointment);
  }
  populateForm(log: PatientLog) {
    console.log(log);
    this.appservice.logForm = log;
  }
  patientlog(patientid: number) {
    console.log(patientid);
    this.router.navigate(['patientlog', patientid]);
  }
  addpatientlog(id: number) {
    console.log(id);
    this.router.navigate(['patientlogform', id]);
  }
  addPayment(id: number) {
    console.log(id);
    this.router.navigate(['payment', id]);
  }

  compareDate(date: string) {
    var latestDate = this.datepipe.transform(this.today, 'yyyy-MM-ddT00:00:00');
    console.log(date);
    console.log(latestDate);
    if (date == latestDate) {
      return true;
    }
    return false;
  }

  loginuser(username: string) {
    this.loginservice.getDoctorId(username).subscribe(
      data => {
        console.log(data);
        this.DoctorId = data;
      }
    )

  }

  comparedoctor(id: number) {
    console.log(this.DoctorId);
    if (this.DoctorId == id) {
      return true;
    }
    else {
      return false;
    }
  }



}
