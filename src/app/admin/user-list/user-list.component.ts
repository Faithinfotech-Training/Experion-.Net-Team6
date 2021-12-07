import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  filter: string;
  page: number = 1;

  constructor(
    public adminService: AdminService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.adminService.getAllUser();
  }

//to update the user

  updateUser(userId: number) {
    this.router.navigate(['/add-user', userId]);
  }

  //to delete the user

  deleteUser(userId: number) {
    if (confirm("Are you sure you want to delete?")) {
      this.adminService.deleteUser(userId).subscribe(
        result => {
          console.log("sucesffully deleted  " + result)
        },
        (error) => {
          console.log(error)
        }
      )
    }window.location.reload();

  }

  



}
