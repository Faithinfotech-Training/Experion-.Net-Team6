import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../shared/admin.service';
import { AuthService } from '../shared/auth.service';
import { LabListService } from '../shared/lab-list.service';
import {LabReportService} from '../shared/lab-report.service';
import { PatientService } from '../shared/patient.service';
import {PrescriptionTest} from '../shared/prescription-test';
import {GeneratedFormView} from '../shared/report-form-view';

@Component({
  selector: 'app-lab-report',
  templateUrl: './lab-report.component.html',
  styleUrls: ['./lab-report.component.css']
})
export class LabReportComponent implements OnInit {


  LogId:number;
  testDetails:PrescriptionTest;

  constructor(public authService:AuthService,public labReportServices:LabReportService,
              public patientService:PatientService,public route:ActivatedRoute,
              public labListService:LabListService,public adminServices:AdminService) { }

  ngOnInit(): void {
    //getting all patient
    this.patientService.bindPatient1();
    //getting all staffs
    this.adminServices.getallStaff();
    this.LogId=this.route.snapshot.params['LogId'];
    //this.labReportServices.formData.LogId=this.LogId;
    //filling the form with test names
    this.labReportServices.getReportFormView(this.LogId).subscribe(
      data=>{console.log(data);
        this.labReportServices.formData = Object.assign({}, data);
      }
    )

  }

  logOut(){
    this.authService.logOut(); 
    
  }

  onSubmit(form:NgForm){
    console.log(form.value);
    console.log("before calling");
    this.updateStatus();
    console.log("Generating report");
    this.labReportServices.addLabReport(form.value).subscribe(
      (result)=>{
        console.log(result);       
      }
    )

    this.resetForm(form);
  }

    //Clear all contents at loading
    resetForm(form?: NgForm) {
      if (form != null) {
        form.resetForm();
      }
    }

    updateStatus(){
    this.labReportServices.updatePrescriptionTest(this.LogId).subscribe(
      (result)=>{
        console.log(result);
      }
    )
    console.log("updated")
    }
  

}
