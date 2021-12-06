import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppointmentService } from '../shared/appointment.service';
import { PatientlogService } from '../shared/patientlog.service';

@Component({
  selector: 'app-patient-record-form',
  templateUrl: './patient-record-form.component.html',
  styleUrls: ['./patient-record-form.component.css']
})
export class PatientRecordFormComponent implements OnInit {
Id:number;
logId:number;
  constructor(public patientlogservice:PatientlogService,public route:ActivatedRoute,public appointmentservice:AppointmentService,
    public router:Router,private toasterService:ToastrService) { }

  ngOnInit(): void {
    this.Id= this.route.snapshot.params['AppointmentId'];
    if(this.Id!=0|| this.Id!=null){
      this.appointmentservice.GetAppointmentbyId(this.Id).subscribe(
        data=>{
          console.log(data);
          this.appointmentservice.logForm=data;
          console.log(this.appointmentservice.logForm);
        }
  
  
      );
    }
    
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.insertLog(form);
   console.log(this.logId);
    //insert
   
  }

  populateFormId(id: number) {
    console.log('POPULATING');
    this.appointmentservice.logForm.LogId = id;
  }

  insertLog(form:NgForm){
    console.log("Inserting a record...");
    console.log(form.value);
    this.patientlogservice.AddLog(form.value).subscribe(
      (result) => {
        console.log(result);
        this.logId=result;
        //this.removeappointment();
        this.addprescription(result);
        this.toasterService.success("Notes and Observations Added");

      }
    );
   // window.location.reload();
  }

  addprescription(id:number){
    console.log("Adding Medicine");
    console.log(id);
    this.populateFormId(id);
    this.router.navigate(['prescriptionmedicine', id]);
  }

 // removeappointment(){

  //  this.appointmentservice.deleteappointment(this.Id).subscribe(

     // (result)=>{

       // console.log(result);

     // }
   // );
 // }
}
