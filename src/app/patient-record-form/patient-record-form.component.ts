import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatientlogService } from '../shared/patientlog.service';

@Component({
  selector: 'app-patient-record-form',
  templateUrl: './patient-record-form.component.html',
  styleUrls: ['./patient-record-form.component.css']
})
export class PatientRecordFormComponent implements OnInit {
patientId:number;
  constructor(public patientlogservice:PatientlogService,public route:ActivatedRoute) { }

  ngOnInit(): void {
    this.patientId= this.route.snapshot.params['PatientId']
  }

}
