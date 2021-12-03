import { DatePipe } from '@angular/common';
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

  constructor(
    public adminService: AdminService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToastrService
  ) { }

  ngOnInit(): void {
    this.Id = this.route.snapshot.params['Id'];

    if (this.Id != 0 || this.Id != null) {
      //getEmployee
      this.adminService.getstaff(this.Id).subscribe(
        data => {
          console.log(data);

          var datePipe = new DatePipe("en-uk");
          let formatedDate: any = datePipe.transform(data.StaffDateofBirth, 'yyyy-MM-dd');
          data.StaffDateofBirth = formatedDate;
          this.adminService.StaffData = data;

        },
        error => console.log(error)
      );
    }
  }


  onSubmit(form?: NgForm) {
    console.log(form.value);
    let Id = this.adminService.StaffData.StaffId;

    if (Id == 0 || Id == null) {
      console.log("inserting record...");
      this.insertstaff(form);
    }
    else {
      console.log("updating record..");
      this.updatestaff(form);
    }
  // this.router.navigateByUrl('staff-list');
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  insertstaff(form: NgForm) {
    console.log("50%");
    this.adminService.insertstaff(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success('Staff Added successfully');

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
        this.toasterService.success('Staff Updated successfully');
      }
    )
  //  window.location.reload();
  }

}
