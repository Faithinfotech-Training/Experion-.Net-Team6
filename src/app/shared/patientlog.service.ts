import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {PatientLogVM} from '../shared/patientlogvm';

@Injectable({
  providedIn: 'root'
})
export class PatientlogService {

  patientlog:PatientLogVM[]
  constructor(public httpClient:HttpClient) { }

  GetPatientPastlog(id:number){
    this.httpClient.get(environment.apiUrl + 'api/patientlog/log/'+id)
    .toPromise().then(
      response => this.patientlog = response as PatientLogVM[])
  }
}
