import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrls: ['./staff-list.component.css']
})
export class StaffListComponent implements OnInit {

  filter: string;
  page: number = 1;

  constructor(
    public adminService: AdminService,
    private router: Router
  ) { }



  ngOnInit(): void {

    this.adminService.getallStaff();
    console.log(this.adminService.staff);
    
  }


 //to update the staff

  updateStaff(Id: number) {
    this.router.navigate(['add-staff', Id, 0]);
  }

  //to delete the staff

  DeleteStaff(Id:number){
    if (confirm("The Staff data and access will be archived !")) {
      this.adminService.getstaff(Id).subscribe(
        (result) => {
          result.IsActive = false;
          this.adminService.updatestaff(result).subscribe(
            (result) => console.log("deleted")
          )
          this.adminService.deleteUser(result.UserId).subscribe(
            (result) => console.group("user removed")
          )
          window.location.reload();
        }
      )
    }
  }
}
