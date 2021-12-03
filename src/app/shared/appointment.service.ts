import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {Appointment} from './Appointment';
import { Doctor } from './doctor';
import { Patient } from './patient';
import { PatientLog } from './patientlog';
@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(public httpClient:HttpClient) { }
  formData1:Appointment=new Appointment();
  appointment:Appointment[];
  patient:Patient[];
  doctors:Doctor[];
  logForm:PatientLog= new PatientLog();
  bindCmdDoctor(){
    this.httpClient.get(environment.apiUrl+"/api/doctor/getalldoctor")
    .toPromise().then(response=>
      this.doctors=response as Doctor[])
  
  }
  bindCmdPatient(){
    this.httpClient.get(environment.apiUrl+"/api/patient/getpatients")
    .toPromise().then(response=>
      this.patient=response as Patient[])
  
  }
  GetAppointmentsListByDoctorId(){
    this.httpClient.get(environment.apiUrl + '/api/appointment/getbydoctor/1')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

  GetAppointmentbyVM(){
    this.httpClient.get(environment.apiUrl + '/api/appointment/Getbyvm')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

  GetAppointmentList(){
    this.httpClient.get(environment.apiUrl + '/api/appointment')
    .toPromise().then(
      response => this.appointment = response as Appointment[])
  }

  GetAppointmentbyId(id:number):Observable<any>{
    return this.httpClient.get(environment.apiUrl+'/api/appointment/'+id);
  }
  insertAppointment(appointment:Appointment):Observable<any>
  {
    return this.httpClient.post(environment.apiUrl+'/api/appointment',appointment);
  
  }

  deleteappointment(id:number):Observable<any>{
    return this.httpClient.get(environment.apiUrl+'/api/appointment/deleteappointment/' +id);
  }
}
