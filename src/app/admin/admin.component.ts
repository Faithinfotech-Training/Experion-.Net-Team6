import { Component, OnInit } from '@angular/core';
import { AdminService } from '../shared/admin.service';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  loggedUser=sessionStorage.getItem('userName')

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {

  }

  logOut(){
    this.authService.logOut();   
  }

}
