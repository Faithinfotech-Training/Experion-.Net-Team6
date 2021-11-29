import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
<<<<<<< HEAD
import { Router, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { StaffListComponent } from './admin/staff-list/staff-list.component';
import { AddstaffComponent } from './admin/addstaff/addstaff.component';
import { DoctorListComponent } from './admin/doctor-list/doctor-list.component';
import { AdddoctorComponent } from './admin/adddoctor/adddoctor.component';
import { NgSearchFilterModule } from 'ng-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { LabReportComponent } from './lab-report/lab-report.component';
import { FrontofficeComponent } from './frontoffice/frontoffice.component';
import { PatientComponent } from './frontoffice/patient/patient.component';
import { PatientlistComponent } from './frontoffice/patientlist/patientlist.component';
import { AppointmentComponent } from './frontoffice/appointment/appointment.component';
>>>>>>> 3bf696965360fe0f9db9393398eeaa68836d9492

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    StaffListComponent,
    AddstaffComponent,
    DoctorListComponent,
    AdddoctorComponent,
    LoginComponent,
    DoctorComponent,
    LabTechnicianComponent,
    LabReportComponent,
    FrontofficeComponent,
    PatientComponent,
    PatientlistComponent,
    AppointmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    NgSearchFilterModule
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
