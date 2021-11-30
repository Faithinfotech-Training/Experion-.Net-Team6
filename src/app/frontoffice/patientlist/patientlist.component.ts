import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from 'src/app/shared/patient';
import { PatientService } from 'src/app/shared/patient.service';

@Component({
  selector: 'app-patientlist',
  templateUrl: './patientlist.component.html',
  styleUrls: ['./patientlist.component.css']
})
export class PatientlistComponent implements OnInit {
  page:number =1;
  filter : string;
  constructor(public patientService:PatientService,private router:Router) { }

  ngOnInit(): void {
    this.patientService.bindPatient();
  }
  //populate form by clicking the column fields
  populateForm(patient:Patient){
    console.log(patient);
    this.patientService.formData =Object.assign({},patient); 
  } 
  //update a patient through routing
  updatePatient(patientId: number){

      console.log(patientId);
      this.router.navigate(['addpatient',patientId])
    }
  
}

  

