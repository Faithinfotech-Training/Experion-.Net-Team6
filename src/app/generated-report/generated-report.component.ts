import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { LabReportService } from '../shared/lab-report.service';

@Component({
  selector: 'app-generated-report',
  templateUrl: './generated-report.component.html',
  styleUrls: ['./generated-report.component.css']
})
export class GeneratedReportComponent implements OnInit {


  page:number=1;
  filter:string;
  loggedUser=sessionStorage.getItem('userName')

  constructor(public authService: AuthService, public labReportService: LabReportService) { }

  ngOnInit(): void {
    //Get all generated results
    this.labReportService.getGeneratedReport();
  }

  logOut(){
    this.authService.logOut();   
  }

}
