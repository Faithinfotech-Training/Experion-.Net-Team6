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

  page:number=1;
  filter:string;
  dummy:number[]=[1,2,3,4,5,6];

  loggedUser=sessionStorage.getItem('userName')

  constructor(public labListService:LabListService,public authService:AuthService,public router:Router) { }

  ngOnInit(): void {
    //get all lab list
    this.labListService.getAllLabList();
  }

  logOut(){
    this.authService.logOut();   
  }

  labReport(LogId:number){
    console.log(LogId);
    this.router.navigate(['report',LogId]);
  }

}
