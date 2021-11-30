import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './patient';
import { Patient1 } from '../shared/patient1';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  formData: Patient = new Patient();
  formData1:Patient1=new Patient1;
  patients: Patient[];
  patients1: Patient1[];
  constructor(private httpClient: HttpClient) { }
  //get patients for binding
  bindPatient() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient/getpatients')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
    console.log(this.patients);
  }
  //get patients for binding
  bindPatient1() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient/getpatients')
      .toPromise()
      .then((response) => (this.patients1 = response as Patient1[]));
    console.log(this.patients1);
  }
  //insert a patient
  insertPatient(patient: Patient): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "api/patient/AddPatient", patient);
<<<<<<< HEAD
=======
  }
  updatePatient(patient: Patient): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "api/patient/updatepatient", patient);
>>>>>>> d9811acf27413af982c9de9be4a171d861689fe8
  }
  //get particular patient
  getPatientById(patientId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + 'api/patient/GetPatientById?id=' + patientId);
  }
}