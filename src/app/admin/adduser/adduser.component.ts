import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {

  UId: number;  //id of user table


  confirmPassword: string

  constructor(
    public adminService: AdminService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.UId = this.route.snapshot.params['userId'];

    if (this.UId != null) {
      this.adminService.getUser(this.UId).subscribe(
        data =>
          this.adminService.userData = data
      )
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  onSubmit(form?: NgForm) {
    if (this.adminService.userData.UserId == 0 || this.adminService.userData.UserId == null) {
      console.log("submitted perfectly");
      this.AddUser(form);
      console.log(this.UId);
      this.resetForm();
      this.adminService.getUser(this.UId).subscribe(
        (result) => {
          if (result.RoleId != 2) {
            console.log("routing");
            console.log(this.UId);
            this.router.navigate(['/add-staff', 0, this.UId]);
          }
          else {
            this.router.navigate(['/add-doctor', this.UId]);
          }
        }
      )
    }
    else {
      this.PutUser(form);
      //this.router.navigate["/admin"];
    }

  }

  AddUser(form: NgForm) {
    console.log("working");
    this.adminService.insertUser(form.value).subscribe(
      (result) => {
        this.UId = result;
        this.adminService.getUser(this.UId).subscribe(
          (result) => {
            console.log(result.RoleId);
            if (result.RoleId != 2) {
              console.log("routing");
              console.log(this.UId);
              this.router.navigate(['/add-staff', 0, this.UId]);
            }
            else {
              this.router.navigate(['/add-doctor', 0, this.UId]);
            }
          }
        )
      }
    )
    console.log("completed");
  }

  PutUser(form: NgForm) {
    console.log("updating");
    this.adminService.updateUser(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
  }





}
