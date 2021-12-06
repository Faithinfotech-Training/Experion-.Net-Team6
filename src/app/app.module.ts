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
import { AuthGuard } from './shared/auth.guard';
import { GeneratedReportComponent } from './generated-report/generated-report.component';
import { LabHomeComponent } from './lab-home/lab-home.component';
import { PrescriptionMedicineComponent } from '../app/prescription-medicine/prescription-medicine.component';
import { PrescriptiontestComponent } from '../app/prescriptiontest/prescriptiontest.component';
import { PaymentComponent } from './frontoffice/payment/payment.component';
import { ViewpaymentComponent } from './frontoffice/viewpayment/viewpayment.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { PatientLogComponent } from './patient-log/patient-log.component';
import { AdduserComponent } from './admin/adduser/adduser.component';
import { UserListComponent } from './admin/user-list/user-list.component';
import { EventsComponent } from './events/events.component';
import { EventComponent } from './events/event/event.component';
import { EventlistComponent } from './events/eventlist/eventlist.component';
import { HomeComponent } from './home/home.component';
import { DatePipe } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RelistStaffComponent } from './admin/relist-staff/relist-staff.component';

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
    PrescriptiontestComponent,
    FrontofficeComponent,
    PaymentComponent,
    ViewpaymentComponent,
    AdduserComponent,
    UserListComponent,
    EventsComponent,
    EventComponent,
    EventlistComponent,
    HomeComponent,
    RelistStaffComponent
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
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [AuthService, AdminService, AuthGuard,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
