import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PrescriptionService } from '../shared/prescription.service';

@Component({
  selector: 'app-prescriptiontest',
  templateUrl: './prescriptiontest.component.html',
  styleUrls: ['./prescriptiontest.component.css']
})
export class PrescriptiontestComponent implements OnInit {
id:number;
  constructor(public prescription:PrescriptionService,private router:Router,private route:ActivatedRoute,
    private toasterService:ToastrService) { }

  ngOnInit(): void {
    this.id=this.route.snapshot.params['LogId'];
    this.prescription.testform.LogId=this.id;
    this.prescription.testform.IsActive=true;
  }
  
  onSubmit(form: NgForm) { 
    console.log(form.value);
    this.addTest(form);
    this.router.navigateByUrl('appointmentlist');
    //insert   
  }

  addTest(form:NgForm){
    console.log("Inserting a record...");
    console.log(form.value);
    this.prescription.AddTest(form.value).subscribe(
      (result) => {
        console.log(result);
        this.toasterService.success("Tests Added");
        
      }
    );
  }

}
