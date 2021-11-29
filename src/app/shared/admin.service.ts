import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Doctor } from './doctor';
import { Staff } from './staff';
import { environment } from "src/environments/environment"

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  //creating instance
  formData: Doctor = new Doctor();
  staff: Staff[];
  doctors: Doctor[];

  constructor(
    private httpClient: HttpClient
  ) { }

  //get all doctor
  getalldoctor() {
    this.httpClient.get(environment.apiUrl + "api/doctor/getalldoctor")
      .toPromise().then(
          result => this.doctors = result as Doctor[]
      )
      console.log(this.doctors);
  }

  getallStaff() {
    this.httpClient.get(environment.apiUrl + "api/staff/getallstaff")
      .toPromise().then(
        response => this.staff = response as Staff[]
      )
  }

}

