import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-adddoctor',
  templateUrl: './adddoctor.component.html',
  styleUrls: ['./adddoctor.component.css']
})
export class AdddoctorComponent implements OnInit {

  Id: number;
  UserId: number;
  checkActive: boolean;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToastrService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.Id = +params.get('Id');
      this.UserId = +params.get('UId');
    })
    this.adminService.formData.UserId = this.UserId;

    this.adminService.getallSpecial();


    if (this.Id != 0 || this.Id != null) {
      //getEmployee
      this.adminService.getdoctor(this.Id).subscribe(
        data => {
          console.log(data);

          var datePipe = new DatePipe("en-uk");
          let formatedDate: any = datePipe.transform(data.DoctorDateofBirth, 'yyyy-MM-dd');
          data.DoctorDateofBirth = formatedDate;

          this.adminService.formData = data;
          this.checkActive = data.IsActive;


        },
        error => console.log(error)
      );
    }

  }

  onSubmit(form?: NgForm) {
    console.log(form.value);
    let Id = this.adminService.formData.DoctorId;
    

    if (Id == 0 || Id == null) {
      form.value.IsActive = true;
      console.log("inserting record...");
      this.insertdoctor(form);
    }
    else {
      form.value.IsActive = this.checkActive;
      console.log("updating record..");
      this.updatedoctor(form);

    }
    // this.router.navigateByUrl('doctor-list');
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //disabling manual date
  disableDate(){
    return false;
  }

  insertdoctor(form: NgForm) {
    console.log("50%");
    console.log(form.value);
    this.adminService.insertdoctor(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success("Doctor details Added");
      }
    )
    //window.location.reload();
    //his.router.navigate(["/admin"]);
  }

  updatedoctor(form: NgForm) {
    console.log("50%");
    this.adminService.updatedoctor(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success("Doctor Details Updated");
      }
    )
  }

}
