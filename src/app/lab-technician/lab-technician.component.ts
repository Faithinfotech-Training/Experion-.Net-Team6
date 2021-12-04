import { Component, OnInit } from '@angular/core'; 
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import {LabListService} from '../shared/lab-list.service';

@Component({
  selector: 'app-lab-technician',
  templateUrl: './lab-technician.component.html',
  styleUrls: ['./lab-technician.component.css']
})
export class LabTechnicianComponent implements OnInit { 

  //Declaring variables for pagination and searching
  page:number=1;
  filter:string;
  //initialising variable for disaplaying user name
  loggedUser=sessionStorage.getItem('userName')

  //Dependency injection through constructor
  constructor(public labListService:LabListService,public authService:AuthService,public router:Router) { }

  

  ngOnInit(): void {
    //get all lab list
    this.labListService.getAllLabList();
  }

  //Function for logging out
  logOut(){
    this.authService.logOut();    
  }

  //Routing to Lab form
  labReport(LogId:number){
    console.log(LogId);
    //sessionStorage.setItem("PatientId", PatientId.toString());
    this.router.navigate(['report',LogId]);
  }

}
