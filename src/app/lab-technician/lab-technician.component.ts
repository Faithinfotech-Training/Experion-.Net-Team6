import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lab-technician',
  templateUrl: './lab-technician.component.html',
  styleUrls: ['./lab-technician.component.css']
})
export class LabTechnicianComponent implements OnInit {

  page:number=1;
  filter:string;
  dummy:number[]=[1,2,3,4,5,6];

  constructor() { }

  ngOnInit(): void {
  }

}
