import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {PatientlogService} from '../shared/patientlog.service';

@Component({
  selector: 'app-patient-log',
  templateUrl: './patient-log.component.html',
  styleUrls: ['./patient-log.component.css']
})
export class PatientLogComponent implements OnInit {
patientId:number;
  constructor(public patientlogservice:PatientlogService,public route:ActivatedRoute) { }

  ngOnInit(): void {
    this.patientId=this.route.snapshot.params['PatientId'];
    this.patientlogservice.GetPatientPastlog(this.patientId);
  }

}
