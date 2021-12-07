import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';
import { Doctor } from 'src/app/shared/doctor';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  filter: string;
  page: number = 1;

  constructor(
    public adminService: AdminService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.adminService.getalldoctor();
  }

  //updating doctor

  updatedoctor(Id: number){
    this.router.navigate(['add-doctor',Id, 0]);
  }

  //deleting doctor

  Deletedoctor(Id:number){
    if (confirm("The Doctor info and access will be archived !")) {
      this.adminService.getdoctor(Id).subscribe(
        (result) => {
          result.IsActive = false;
          this.adminService.updatedoctor(result).subscribe(
            (result) => console.log("activated")
          )
          this.adminService.deleteUser(result.UserId).subscribe(
            (result) => console.log("user deactivated")
          )
          window.location.reload()
        }
      )
    }
  }
}
