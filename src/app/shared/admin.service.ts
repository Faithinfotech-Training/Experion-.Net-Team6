import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Doctor } from './doctor';
import { Staff } from './staff';
import { environment } from "src/environments/environment"
import { Observable } from 'rxjs';
import { Special } from "./doctorspecialization"
import { User } from './user';
import { Role } from './role';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  //creating instance
  formData: Doctor = new Doctor();
  StaffData: Staff = new Staff();
  userData: User= new User();
  roleData: Role = new Role();
  staff: Staff[];
  doctors: Doctor[];
  special: Special[];
  user: User[];
  role: Role[];

  constructor(
    private httpClient: HttpClient
  ) { }

  //get all doctor
  getalldoctor() {
    this.httpClient.get(environment.apiUrl + "/api/doctor/getalldoctor")
      .toPromise().then(
          result => this.doctors = result as Doctor[]
      )
      console.log(this.doctors);
  }
 

  getallStaff() {
    this.httpClient.get(environment.apiUrl + "/api/staff/getallstaff")
      .toPromise().then(
        response => this.staff = response as Staff[]
      )
  }

  getallSpecial() {
    this.httpClient.get(environment.apiUrl + "/api/doctor/getallspecialization") 
    .toPromise().then(
      result => this.special = result as Special[]
    )
    console.log(this.special);
  }


  insertdoctor(doctor: Doctor): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/doctor/Adddoctor", doctor);
  }

  updatedoctor(doctor: Doctor): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/doctor/putdoctor", doctor);
  }

  insertstaff(staff: Staff): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/staff/Addstaff", staff);
  }

  updatestaff(staff: Staff): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/staff/putstaff", staff);
  }

  getstaff(id: number): Observable<any> {
   return this.httpClient.get(environment.apiUrl + "/api/staff/GetStaff/" + id);
  }

  getdoctor(id: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + "/api/doctor/GetADoctor/" + id);
  }




  //User API calls

  getUser(id: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + "/api/UserRole/" + id)
   }

   getAllUser() {
    this.httpClient.get(environment.apiUrl + "/api/UserRole").
    toPromise().then(
      result => this.user = result as User[]
    )
   }

  insertUser(user: User): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/UserRole", user);
  }

  updateUser(user: User): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/UserRole", user);
  }

  deleteUser(id:number): Observable<any> {
    return this.httpClient.delete(environment.apiUrl + "/api/UserRole/" + id);
  }

  //Role API calls
  getAllRole() {
    this.httpClient.get(environment.apiUrl + "/api/UserRole/role").
    toPromise().then(
      result => this.user = result as User[]
    )
   }

   insertRole(role: Role): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/UserRole/role", role);
  }

  updateRole(role: Role): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/UserRole/role", role);
  }



}

