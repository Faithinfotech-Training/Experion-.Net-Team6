import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { JwtResponse } from '../shared/jwt-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  isSubmitted = false;
  error = '';
  jwtResponse: any = new JwtResponse();



  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {

    //form Group
    this.loginForm = this.formBuilder.group(
      {
        UserName: ['', [Validators.required, Validators.minLength(2)]],
        UserPassword: ['', [Validators.required]]
      }
    );
  }

  //get Controls
  get formControls() {
    return this.loginForm.controls;
  }

  //verify credentials
  loginCredentials() {
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //If the value is invalid
    if (this.loginForm.invalid) {
      return;
    }

    //valid
    if (this.loginForm.invalid) {
      //calling method from AuthService
      this.authService.loginVerify(this.loginForm.value).subscribe(data => {
        console.log(data);
        //storing recieved data to jwtresponse variable
        this.jwtResponse = data;

        //storing in browser memory
        sessionStorage.setItem("jwtToken", this.jwtResponse.token);

        //checking the role and redirecting according to the role
        if (this.jwtResponse.RoleId === 1) {
          //logged as Admin
          console.log("Admin");

          //storing in localstorage/sessionStorage
          localStorage.setItem("userName", this.jwtResponse.uName);
          sessionStorage.setItem("userName", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId.toString())
          this.router.navigateByUrl('admin');
        }
        else if (this.jwtResponse.RoleId === 2) {
          console.log("Doctor");

          //storing in localstorage/sessionStorage
          localStorage.setItem("userName", this.jwtResponse.uName);
          sessionStorage.setItem("userName", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId.toString())
          this.router.navigateByUrl('doctor');
        }
        else if (this.jwtResponse.RoleId === 3) {
          console.log("Lab technician");

          //storing in localstorage/sessionStorage
          localStorage.setItem("userName", this.jwtResponse.uName);
          sessionStorage.setItem("userName", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId.toString())
          this.router.navigateByUrl('lab');
        }
        else if (this.jwtResponse.RoleId === 2) {
          console.log("Front Office");

          //storing in localstorage/sessionStorage
          localStorage.setItem("userName", this.jwtResponse.uName);
          sessionStorage.setItem("userName", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId.toString())
          this.router.navigateByUrl('frontoffice');
        }
        else {
          this.error = "Sorry!....Invalid Authorization"
        }
      },error => { this.error = "Invalid User name Or Password. Try again" }
      );
    }
  }
}
