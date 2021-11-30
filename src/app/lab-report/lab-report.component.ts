import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-lab-report',
  templateUrl: './lab-report.component.html',
  styleUrls: ['./lab-report.component.css']
})
export class LabReportComponent implements OnInit {

  constructor(public authService:AuthService) { }

  ngOnInit(): void {
  }

  logOut(){
    this.authService.logOut();
    
  }

}
