import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/shared/admin.service';
import { Doctor } from 'src/app/shared/doctor';
import { Staff } from "src/app/shared/staff";

@Component({
  selector: 'app-relist-staff',
  templateUrl: './relist-staff.component.html',
  styleUrls: ['./relist-staff.component.css']
})
export class RelistStaffComponent implements OnInit {

  filter1: string;
  filter2: string;
  page: number = 0;
  doctorData: Doctor;

  constructor(
    public adminService: AdminService,
    private router: Router,
    private toasterService: ToastrService
  ) { }

  ngOnInit(): void {
    this.adminService.getallStaff();
    this.adminService.getalldoctor();

  }

  //for edting the doctor

  updatedoctor(Id: number) {
    this.router.navigate(['add-doctor', Id, 0]);
  }

  // for activating the doctor

  ReActivatedoc(Id: number) {
    if (confirm("Are you sure you want to re-Activate this Doctor?")) {
      this.adminService.getdoctor(Id).subscribe(
        (result) => {
          result.IsActive = true;
          this.adminService.updatedoctor(result).subscribe(
            (result) => console.log("activated")
          )
          window.location.reload()
        }
      )
    }
  }

  //for editing the staff

  updateStaff(Id: number) {
    this.router.navigate(['add-staff', Id, 0]);
  }

  //for activating the staff

  ReActivateStaff(Id: number) {
    if (confirm("Are you sure you want to reactivate this staff?")) {
      this.adminService.getstaff(Id).subscribe(
        (result) => {
          result.IsActive = true;
          this.adminService.updatestaff(result).subscribe(
            (result) => console.log("activated")
          )
          window.location.reload();
        }
      )
    }
  }
    

}
