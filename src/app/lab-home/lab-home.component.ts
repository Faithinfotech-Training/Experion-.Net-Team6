import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-lab-home',
  templateUrl: './lab-home.component.html',
  styleUrls: ['./lab-home.component.css']
})
export class LabHomeComponent implements OnInit {

  loggedUser=sessionStorage.getItem('userName')
  
  constructor(public authService:AuthService) { }

  ngOnInit(): void {
  }
  logOut(){
    this.authService.logOut();
  }
}
