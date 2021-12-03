import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {PatientLogVM} from '../shared/patientlogvm';
import {PatientLog} from '../shared/patientlog';
import { Observable } from 'rxjs';
import { GeneratedFormView } from './report-form-view';

@Injectable({
  providedIn: 'root'
})
export class PatientlogService {
  logForm:PatientLog= new PatientLog();
  patientlog:PatientLogVM[]
  labreport:GeneratedFormView[]
  constructor(public httpClient:HttpClient) { }

  GetPatientPastlog(id:number){
    this.httpClient.get(environment.apiUrl + '/api/patientlog/log/'+id)
    .toPromise().then(
      response => this.patientlog = response as PatientLogVM[])
  }

  AddLog(log: PatientLog): Observable<any> {
    return this.httpClient.post(environment.apiUrl + '/api/patientlog', log)
  }

  Getlabresults(id:number){
    this.httpClient.get(environment.apiUrl + '/api/labreport/'+id).toPromise().then( response => this.labreport = response as GeneratedFormView[]) 
  }
  
}
