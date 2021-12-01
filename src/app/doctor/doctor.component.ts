import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  constructor(public authservice: AuthService) { }

  ngOnInit(): void {
  }
  logout() {
    this.authservice.logOut();
  }
}
