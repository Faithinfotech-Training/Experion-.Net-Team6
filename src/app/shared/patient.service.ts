import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { Patient } from './patient';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  formData:Patient=new Patient();
  patients:Patient[];
  constructor(private httpClient:HttpClient) { }
  //get patients for binding
  bindPatient() {
    this.httpClient
      .get(environment.apiUrl + 'api/patient/getpatients')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
  } 
  //insert a patient
  insertPatient(patient: Patient): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "api/patient/AddPatient", patient);
  }
  updatePatient(patient: Patient):Observable<any> {
    return this.httpClient.put(environment.apiUrl+"api/patient/updatepatient",patient);
  } 
  //get particular patient
  getPatientById(patientId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + 'api/patient/GetPatientById?id=' + patientId);
  }
}