import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AppointmentService} from '../shared/appointment.service';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {

  page:number=1;
  
  constructor(public appservice:AppointmentService,public router:Router) { }

  ngOnInit(): void {
    this.appservice.GetAppointmentbyVM();
  }

  patientlog(patientid:number){
    console.log(patientid);
    this.router.navigate(['patientlog',patientid])
  }

}
