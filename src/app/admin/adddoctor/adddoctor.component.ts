import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-adddoctor',
  templateUrl: './adddoctor.component.html',
  styleUrls: ['./adddoctor.component.css']
})
export class AdddoctorComponent implements OnInit {

  constructor(
    public adminService: AdminService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.adminService.getallSpecial();
    console.log(this.adminService.special);
  }
  onSubmit(form?: NgForm)
  {
    console.log(form.value);
    let Id= this.adminService.formData.DoctorId;

    if(Id==0 || Id==null){
      console.log("inserting record...");
      console.log(form.value);
      this.insertdoctor(form);
    }
    else{
      console.log("updating record..");
      this.updatedoctor(form);
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  insertdoctor(form: NgForm){
    console.log("50%");
    console.log(form.value);
    this.adminService.insertdoctor(form.value).subscribe(
      (result) => {
        console.log(result);
        //this.resetForm(form);
      }
    )
    //window.location.reload();
  }

  updatedoctor(form: NgForm) {
    console.log("50%");
    this.adminService.updatedoctor(form.value).subscribe(
      (result) => {
        console.log(result);
        //this.resetForm(form);
      }
    )
    //window.location.reload();
  }

}
