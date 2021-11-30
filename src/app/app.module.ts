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
import { NgxPaginationModule } from 'ngx-pagination';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { LabReportComponent } from './lab-report/lab-report.component';
import { FrontofficeComponent } from './frontoffice/frontoffice.component';
import { PatientComponent } from './frontoffice/patient/patient.component';
import { PatientlistComponent } from './frontoffice/patientlist/patientlist.component';
import { AppointmentComponent } from './frontoffice/appointment/appointment.component';
import { DoctorComponent } from './doctor/doctor.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './shared/auth.service';
import { AdminService } from './shared/admin.service';
import {AuthGuard} from './shared/auth.guard';

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
    AppointmentComponent,
    AppointmentListComponent,
    PatientLogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AuthService,AdminService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
