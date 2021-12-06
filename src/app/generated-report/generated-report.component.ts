import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { LabReportService } from '../shared/lab-report.service';

@Component({
  selector: 'app-generated-report',
  templateUrl: './generated-report.component.html',
  styleUrls: ['./generated-report.component.css']
})
export class GeneratedReportComponent implements OnInit {


  page: number = 1;
  filter: string;
  loggedUser = sessionStorage.getItem('userName')
role=localStorage.getItem('ACCESS_ROLE');
  constructor(public authService: AuthService, public labReportService: LabReportService,
    private router: Router) { }

  ngOnInit(): void {
    //Get all generated results
    this.labReportService.getGeneratedReport();
  }

  logOut() {
    this.authService.logOut();
  }

  updateReport(LogId: number, LabReportId: number) {
    this.labReportService.updateLabReportTable(LabReportId).subscribe(
      (result) => {
        console.log(result);
      }
    )
    this.router.navigate(['report', LogId])
  }

  generatepdf(Id: number) {
    console.log(Id);
    this.router.navigate(['/reportpdf', Id]);
  }
}
