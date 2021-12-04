
import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/shared/patient';
import { NgForm } from '@angular/forms';
import { PatientService } from 'src/app/shared/patient.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  PatientId: number;
  patient: Patient = new Patient();
  Id: number;

  constructor(
    public patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToastrService) { }

  ngOnInit(): void {
    this.Id = this.route.snapshot.params['patId'];
    if (this.Id != 0 || this.Id != null) {
      
      this.patientService.getPatientById(this.Id).subscribe(
        data => {
          console.log(data);
          this.patientService.formData = data;
        },
        error => console.log(error)

      );

    }


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
        this.resetForm(form);
        this.toasterService.success('Patient Added successfully');

      }
    )
   // window.location.reload();
  }

  updatePatient(form: NgForm) {
    
    this.patientService.updatePatient(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success('Patient Updated successfully');

      }
    )
 //   window.location.reload();
  }
  

}
