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
  PatientId: number;
  Id:number;
  filter : string;
  route: any;
  constructor(public patientService:PatientService,private router:Router) { }
  role=localStorage.getItem('ACCESS_ROLE');
  ngOnInit(): void {
    this.patientService.bindPatient();

   
  }
  /*populateForm(pat: Patient){
    console.log(pat);
    this.patientService.formData1=Object.assign({} ,pat);
 }*/
 //update a patient through routing
onclick(patientId: number){
 console.log(patientId);
 this.router.navigate(['addpatient', patientId]);
 
} 
updateStatus(PatientId: number){

    this.patientService.updatePatientByActive(PatientId).subscribe(

      (result)=>{

        console.log(result);

      }

    )
   window.location.reload();
  }
 
}


