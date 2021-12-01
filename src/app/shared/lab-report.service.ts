import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LabReport } from './lab-report';
import { PatientService } from './patient.service';
import {ReportFormView} from '../shared/report-form-view';
import { Observable } from 'rxjs';
import { PrescriptionTest } from './prescription-test';

@Injectable({
  providedIn: 'root'
})
export class LabReportService {


  formData:LabReport=new LabReport;
  generatedResults:ReportFormView[];
  testDetails:PrescriptionTest;

  constructor(private httpClient:HttpClient,public patientService:PatientService) { }

  addLabReport(report:LabReport){
    return this.httpClient.post(environment.apiUrl+"/api/labreport/addreport",report);
  }

  getReportFormView(LogId:number):Observable<any>{
    return this.httpClient.get(environment.apiUrl+"/api/labtest/"+LogId)

  }

  getGeneratedReport(){
    return this.httpClient.get(environment.apiUrl+"/api/labreport")
    .toPromise().then(
      Response=>this.generatedResults=Response as ReportFormView[]
    )
  }

  getPrescriptionTest(LogId:number):Observable<any>{
    return this.httpClient.get(environment.apiUrl+"/api/labtest/"+LogId)
  }

  updatePrescriptionTest(testDetails:PrescriptionTest){
    return this.httpClient.put(environment.apiUrl+"/api/labtest",testDetails)
  }


}
