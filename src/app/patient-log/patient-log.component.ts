import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {PatientlogService} from '../shared/patientlog.service';
import {PatientService} from '../shared/patient.service';

@Component({
  selector: 'app-patient-log',
  templateUrl: './patient-log.component.html',
  styleUrls: ['./patient-log.component.css']
})
export class PatientLogComponent implements OnInit {
patientId:number;
  constructor(public patientlogservice:PatientlogService,public route:ActivatedRoute,public patientService:PatientService) { }

  ngOnInit(): void {
   this.patientId=this.route.snapshot.params['PatientId'];
   this.patientService.GetPatientPastlog(this.patientId);
  // console.log(this.patientService.getPatientById(this.patientId));
   this.patientlogservice.GetPatientPastlog(this.patientId);
   this.patientlogservice.Getlabresults(this.patientId);
  }

}
