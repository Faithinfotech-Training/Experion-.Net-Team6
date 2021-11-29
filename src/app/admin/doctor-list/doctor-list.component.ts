import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';
import { Doctor } from 'src/app/shared/doctor';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  constructor(
    public adminService: AdminService,
  ) { }

  ngOnInit(): void {
    this.adminService.getalldoctor();
  }

}
