import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {PrescriptionMedicine} from '../shared/prescriptionmedicine';
import { PrescriptionTest } from './prescription-test';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {
medicineform:PrescriptionMedicine= new PrescriptionMedicine();
testform:PrescriptionTest= new PrescriptionTest();

  constructor(public httpClient:HttpClient) { }

  AddMedicine(prescription: PrescriptionMedicine): Observable<any> {
    return this.httpClient.post(environment.apiUrl + '/api/prescmedicine/AddPrescMedicine', prescription);
  }

  AddTest(test: PrescriptionTest): Observable<any> {
    return this.httpClient.post(environment.apiUrl + '/api/labtest', test);
  }

  
}
