import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { User } from './user';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,private router:Router) { }

  //get a user
  getUserByPassword(user:User){
    return this.httpClient.get(environment.apiUrl+"api/login/getuser/"+user.UserName+"/"+user.Password);

  }

  //Authorize user
  public loginVerify(user:User){

    return this.httpClient.get(environment.apiUrl+"api/login/"+user.UserName+"/"+user.Password);

  }

  //Logout
  public logOut(){
    localStorage.clear();
    sessionStorage.clear();
    this.router.navigateByUrl('');
  }
}
