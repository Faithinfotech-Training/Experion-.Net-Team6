import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { Patient } from './patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
//create an instance of patient
formData:Patient=new Patient();
patients:Patient[];
  constructor(private httpClient:HttpClient) { }
}
