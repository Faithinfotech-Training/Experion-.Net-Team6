import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LabReport } from './lab-report';
import { PatientService } from './patient.service';
import { GeneratedFormView } from '../shared/report-form-view';
import { Observable } from 'rxjs';
import { PrescriptionTest } from './prescription-test';

@Injectable({
  providedIn: 'root'
})
export class LabReportService {


  formData: LabReport = new LabReport;
  generatedResults: GeneratedFormView[];
  testDetails: PrescriptionTest;

  constructor(private httpClient: HttpClient, public patientService: PatientService) { }

  addLabReport(report: LabReport) {
    return this.httpClient.post(environment.apiUrl + "/api/labreport/addreport", report)
  }

  getReportFormView(LogId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + "/api/labtest/GetFormView/" + LogId)
  } 

  getGeneratedReport() {
    return this.httpClient.get(environment.apiUrl + "/api/labreport/VM")
      .toPromise().then(
        Response => this.generatedResults = Response as GeneratedFormView[]
      )
  }

  getPrescriptionTest(LogId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + "/api/labtest/" + LogId)
  }

  updatePrescriptionTest(LogId: number):Observable<any>{
    //console.log("inside services");
    //console.log(environment.apiUrl + "/api/labtest/" + LogId);
    return this.httpClient.get(environment.apiUrl + "/api/labtest/updatestatus/" + LogId)
  }


}
