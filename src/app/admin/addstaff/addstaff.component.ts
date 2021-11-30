import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-addstaff',
  templateUrl: './addstaff.component.html',
  styleUrls: ['./addstaff.component.css']
})
export class AddstaffComponent implements OnInit {

  constructor(
    public adminService: AdminService
  ) { }

  ngOnInit(): void {
  }


  onSubmit(form?: NgForm)
  {
    console.log(form.value);
    let Id= this.adminService.staffData.staffId;

    if(Id==0 || Id==null){
      console.log("inserting record...");
      this.insertstaff(form);
    }
    else{
      console.log("updating record..");
      this.updatestaff(form);
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  insertstaff(form: NgForm){
    console.log("50%");
    this.adminService.insertstaff(form.value).subscribe(
      
      (result) => {
        console.log(result);
        //this.resetForm(form);
      }
    )
    //window.location.reload();
  }

  updatestaff(form: NgForm) {
    console.log("50%");
    this.adminService.updatestaff(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
    window.location.reload();
  }

}
