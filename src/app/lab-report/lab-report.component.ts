import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from '../shared/admin.service';
import { AuthService } from '../shared/auth.service';
import { LabListService } from '../shared/lab-list.service';
import {LabReportService} from '../shared/lab-report.service';
import { PatientService } from '../shared/patient.service';
import {PrescriptionTest} from '../shared/prescription-test';
import {GeneratedFormView} from '../shared/report-form-view';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lab-report',
  templateUrl: './lab-report.component.html',
  styleUrls: ['./lab-report.component.css']
})
export class LabReportComponent implements OnInit {


  LogId:number;
  testDetails:PrescriptionTest;
  loggedUser=localStorage.getItem('userName');


  constructor(public authService:AuthService,public labReportServices:LabReportService,
              public patientService:PatientService,public route:ActivatedRoute,
              public labListService:LabListService,public adminServices:AdminService,public router:Router,
              public toastrService:ToastrService) { }

  ngOnInit(): void {
    //getting all patient
    this.patientService.bindPatient1(); 
    //getting all staffs
    this.adminServices.getallStaff();
    this.LogId=this.route.snapshot.params['LogId'];
    //get staff Id
    //var staffId=this.labReportServices.getSyaffId(this.loggedUser);
    this.labReportServices.getReportFormView(this.LogId).subscribe(
      data=>{console.log(data);
        this.labReportServices.formData = Object.assign({}, data);
        this.labReportServices.getStaffId(this.loggedUser).subscribe(
          data=>{console.log(data);
            this.labReportServices.formData.StaffId = data;
          }
        )
      }
      
    )

    //this.labReportServices.formData.LogId=this.LogId;
    //filling the form with test names


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
    this.toastrService.success("Report Generated Successfuly!");
    this.resetForm(form);
    this.router.navigate(['/lab']);
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
