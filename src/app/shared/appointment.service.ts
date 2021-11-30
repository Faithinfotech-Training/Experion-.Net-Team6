import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {Appointment} from './Appointment';
import { Patient } from './patient';
@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(public httpClient:HttpClient) { }

  appointment:Appointment[];
  patient:Patient[];

  GetAppointmentsListByDoctorId(){
    this.httpClient.get(environment.apiUrl + 'api/appointment/getbydoctor/1')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

  GetAppointmentbyVM(){
    this.httpClient.get(environment.apiUrl + 'api/appointment/getbyvm')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

  GetAppointmentList(){
    this.httpClient.get(environment.apiUrl + 'api/appointment')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

}
