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
    private route: ActivatedRoute) { }

  ngOnInit(): void {


  }
  onSubmit(form?: NgForm) {
    console.log(form.value);
    let Id = this.patientService.formData.PatientId;

    if (Id == 0 || Id == null) {
      console.log("inserting record...");
      this.insertPatient(form);
    }
    else {
      console.log("updating record..");
      this.updatePatient(form);
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  insertPatient(form: NgForm) {
    //console.log(form.value);
    this.patientService.insertPatient(form.value).subscribe(

      (result) => {
        console.log(result);
        //this.resetForm(form);
      }
    )
    //window.location.reload();
  }

  updatePatient(form: NgForm) {
    
    this.patientService.updatePatient(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
    window.location.reload();
  }

}
