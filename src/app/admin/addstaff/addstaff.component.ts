import { DatePipe } from '@angular/common';
import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';


@Component({
  selector: 'app-addstaff',
  templateUrl: './addstaff.component.html',
  styleUrls: ['./addstaff.component.css']
})
export class AddstaffComponent implements OnInit {

  Id: number;
  UId: number;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params =>{
      this.Id = +params.get('Id');
      this.UId = +params.get('UId');
    })
    this.adminService.StaffData.UserId = this.UId;

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
          console.log(this.adminService.StaffData)
        

        },
        error => console.log(error)
      );
    }
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

  insertstaff(form: NgForm) {
    console.log("50%");
    console.log(form.value);
    this.adminService.insertstaff(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
    window.location.reload();
    this.router.navigate(["/admin"]);
  }

  updatestaff(form: NgForm) {
    console.log("50%");
    this.adminService.updatestaff(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
    //window.location.reload();
    //this.router.navigate(["/admin"]);
  }

}
