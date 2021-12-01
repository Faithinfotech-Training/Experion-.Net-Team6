import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from '../shared/appointment.service';
import { PatientLog } from '../shared/patientlog';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {

  page: number = 1;

  constructor(public appservice: AppointmentService, public router: Router) { }

  ngOnInit(): void {
    this.appservice.GetAppointmentbyVM();
  }
  populateForm(log:PatientLog){
  console.log(log);
  this.appservice.logForm=log;
}
  patientlog(patientid: number) {
    console.log(patientid);
    this.router.navigate(['patientlog', patientid]);
  }
  addpatientlog(id: number) {
    console.log(id);
    this.router.navigate(['patientlogform', id]);
  }

 

    


}
