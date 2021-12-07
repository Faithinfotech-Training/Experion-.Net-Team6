import { DatePipe } from '@angular/common';
import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-addstaff',
  templateUrl: './addstaff.component.html',
  styleUrls: ['./addstaff.component.css']
})
export class AddstaffComponent implements OnInit {

  Id: number;
  UId: number;
  CheckActive: boolean;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToastrService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params =>{
      this.Id = +params.get('Id');
      this.UId = +params.get('UId');
    })
    this.adminService.StaffData.UserId = this.UId;

    //take uid and id based on params

    if (this.Id == 0 || this.Id == null) {
      this.adminService.getUser(this.UId).subscribe(
        data => {
          this.adminService.StaffData.RoleId = data.RoleId
        }
      )
      
    }


    if (this.Id != 0 || this.Id != null) {
      this.adminService.StaffData.StaffId = this.Id;
      //getEmployee
      this.adminService.getstaff(this.Id).subscribe(
        data => {
          console.log(data);

          var datePipe = new DatePipe("en-uk");
          let formatedDate: any = datePipe.transform(data.StaffDateofBirth, 'yyyy-MM-dd');
          data.StaffDateofBirth = formatedDate;
          this.adminService.StaffData = data;
          this.CheckActive = data.IsActive;
          console.log(this.adminService.StaffData)
        

        },
        error => console.log(error)
      );
    }

    console.log(this.CheckActive);
  }

  

  onSubmit(form?: NgForm) {
    console.log(form.value);
    let Id = this.adminService.StaffData.StaffId;
    let role = this.adminService.StaffData.RoleId;
    console.log(form.value);

    if (Id == 0 || Id == null) {
      console.log("inserting record...");
      this.insertstaff(form);
    }
    else {
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

  //disabling manual date entry

  disableDate(){
    return false;
  }

  //staff insertion

  insertstaff(form: NgForm) {
    console.log("50%");
    form.value.IsActive = true;
    this.adminService.insertstaff(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success('Staff Added successfully');

      }
    )
  //  window.location.reload();
   // this.router.navigate(["/admin"]);
  }

//staff updastion

  updatestaff(form: NgForm) {
    console.log("50%");
    form.value.IsActive = this.CheckActive
    this.adminService.updatestaff(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success('Staff Updated successfully');
      }
    )
    //window.location.reload();
    //this.router.navigate(["/admin"]);
  }

}
