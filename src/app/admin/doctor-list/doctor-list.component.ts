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

  updatedoctor(Id: number){
    this.router.navigate(['add-doctor',Id]);
  }
}
