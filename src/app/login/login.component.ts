import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!:FormGroup;
  isSubmitted= false;
  error='';


  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {

    //form Group
    this.loginForm=this.formBuilder.group(
      {
        UserName:['',[Validators.required,Validators.minLength(2)]],
        UserPassword:['',[Validators.required]]
      }
    );
  }

  //get Controls
  get formControls(){
    return this.loginForm.controls;
  }

  //verify credentials
  loginCredentials(){
    this.isSubmitted=true;
    console.log(this.loginForm.value);

    //If the value is invalid
    if(this.loginForm.invalid){
      return;
    }

    //valid
    if(this.loginForm.invalid){
      //calling method 
    }
  }
}
