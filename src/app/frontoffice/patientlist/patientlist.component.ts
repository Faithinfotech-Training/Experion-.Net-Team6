import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patientlist',
  templateUrl: './patientlist.component.html',
  styleUrls: ['./patientlist.component.css']
})
export class PatientlistComponent implements OnInit {
  page:number =1;
  filter : string;
    constructor(private router:Router) { }

  ngOnInit(): void {
   
  }
  AddApponitment(){

    
    this.router.navigate(['/appointment'])
  } 
 

  }

