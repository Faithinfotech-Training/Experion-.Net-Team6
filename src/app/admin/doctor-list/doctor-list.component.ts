import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {

  data = [
    {
      id: 1,
      name: "afeez",
      roid: 2,
      age: 21,
      gender: "male",
      dob: "2-2-1990",
      con: 21212,
      loc: "rrr",
      act: true
    },
    {
      id: 1,
      name: "afeez",
      roid: 2,
      age: 21,
      gender: "male",
      dob: "2-2-1990",
      con: 21212,
      loc: "rrr",
      act: true
    },
  ]


  constructor() { }

  ngOnInit(): void {
  }

}
