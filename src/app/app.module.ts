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
import { PatientRecordFormComponent } from './patient-record-form/patient-record-form.component';
import { AuthService } from './shared/auth.service';
import { AdminService } from './shared/admin.service';
import {AuthGuard} from './shared/auth.guard';
import { GeneratedReportComponent } from './generated-report/generated-report.component';
import { LabHomeComponent } from './lab-home/lab-home.component';
import { PrescriptionMedicineComponent } from './prescription-medicine/prescription-medicine.component';
import {PrescriptiontestComponent} from './prescriptiontest/prescriptiontest.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { PatientLogComponent } from './patient-log/patient-log.component';

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
    PatientLogComponent,
    GeneratedReportComponent,
    LabHomeComponent,
    PatientRecordFormComponent,
    PrescriptionMedicineComponent,
    PrescriptiontestComponent
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
