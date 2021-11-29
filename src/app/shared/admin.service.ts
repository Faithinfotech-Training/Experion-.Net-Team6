import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Doctor } from 'src/app/shared/doctor';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  formData: Doctor = new Doctor();
  doctors: Doctor[];

  constructor(
    private httpClient: HttpClient
  ) { }

  //get all doctor
  getalldoctor() {
    this.httpClient.get(environment.apiUrl + "api/doctor/getalldoctor")
      .toPromise().then(
        response => this.doctors = response as Doctor[]
      )
  }
}
