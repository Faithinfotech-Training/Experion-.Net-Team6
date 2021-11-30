import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/shared/patient';
import { NgForm } from '@angular/forms';
import { PatientService } from 'src/app/shared/patient.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  PatientId: number; 
  patient: Patient = new Patient();

  constructor(
    public patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute)
   {}

  ngOnInit(): void {
 this.PatientId = this.route.snapshot.params['patientId'];
 if (this.PatientId != 0 || this.PatientId != null) {
   //get patient
   this.patientService.getPatientById(this.PatientId).subscribe((data) => {
     console.log(data);
     this.patientService.formData = Object.assign({}, data);
     this.patientService.formData = data;
     this.patientService.formData = Object.assign({}, data);
   });
 }
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.patientService.formData.patientId;
    if (addId == 0 || addId == null) {
      //Insert
      this.insertPatient(form);
    } else {
      console.log('Updating record...');
      //Update
      this.updatePatient(form);
    }
  }
  //Clear all content at Initialization
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }
  //Insert

  insertPatient(form?: NgForm) {
    console.log('Inserting a record...');

    this.patientService.insertPatient(form.value).subscribe((result) => {
      console.log(result);

      this.resetForm(form);
    });
  }
  //Update
  updatePatient(form?: NgForm) {
    console.log('Updating a record...');

    this.patientService.updatePatient(form.value).subscribe((result) => {
      console.log(result);

      this.resetForm(form);
    });

   // window.location.reload();
  }
}