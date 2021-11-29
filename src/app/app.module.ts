import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { StaffListComponent } from './admin/staff-list/staff-list.component';
import { AddstaffComponent } from './admin/addstaff/addstaff.component';
import { DoctorListComponent } from './admin/doctor-list/doctor-list.component';
import { AdddoctorComponent } from './admin/adddoctor/adddoctor.component';
import { NgSearchFilterModule } from 'ng-search-filter';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    StaffListComponent,
    AddstaffComponent,
    DoctorListComponent,
    AdddoctorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    NgSearchFilterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
