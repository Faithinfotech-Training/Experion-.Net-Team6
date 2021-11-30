import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrls: ['./staff-list.component.css']
})
export class StaffListComponent implements OnInit {

  data = [
    {
      id: 1,
      name: "afeez",
      roid: 2,
      age: 21,
      gender: "male",
      dob: "2-2-1990",
      con: 21212,
      loc: "rrr",
      act: true
    },
    {
      id: 1,
      name: "afeez",
      roid: 2,
      age: 21,
      gender: "male",
      dob: "2-2-1990",
      con: 21212,
      loc: "rrr",
      act: true
    },
  ]


  constructor(
    public adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.adminService.getallStaff();
    console.log(this.adminService.staff);
  }

}
