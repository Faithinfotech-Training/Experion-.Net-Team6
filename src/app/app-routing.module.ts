import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdddoctorComponent } from './admin/adddoctor/adddoctor.component';
import { AddstaffComponent } from './admin/addstaff/addstaff.component';
import { AdminComponent } from './admin/admin.component';
import { DoctorListComponent } from './admin/doctor-list/doctor-list.component';
import { StaffListComponent } from './admin/staff-list/staff-list.component';
import { AppointmentComponent } from './frontoffice/appointment/appointment.component';
import { PatientComponent } from './frontoffice/patient/patient.component';
import { PatientlistComponent } from './frontoffice/patientlist/patientlist.component';
import { LabReportComponent } from './lab-report/lab-report.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { DoctorComponent } from './doctor/doctor.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { LoginComponent } from './login/login.component';
//import { PatientLogComponent } from './patient-log/patient-log.component';
import { PatientRecordFormComponent } from './patient-record-form/patient-record-form.component';
import { AuthGuard } from './shared/auth.guard';
import { PrescriptionMedicineComponent } from '../app/prescription-medicine/prescription-medicine.component';
import { PrescriptiontestComponent } from '../app/prescriptiontest/prescriptiontest.component';
import { FrontofficeComponent } from './frontoffice/frontoffice.component';
import { LabHomeComponent } from './lab-home/lab-home.component';
import { GeneratedReportComponent } from './generated-report/generated-report.component';
import { PatientLogComponent } from './patient-log/patient-log.component';
import { PaymentComponent } from './frontoffice/payment/payment.component';
import { ViewpaymentComponent } from './frontoffice/viewpayment/viewpayment.component'
import { AdduserComponent } from './admin/adduser/adduser.component';
import { UserListComponent } from './admin/user-list/user-list.component';
import { EventlistComponent } from './events/eventlist/eventlist.component';
import { EventComponent } from './events/event/event.component';
import { HomeComponent } from './home/home.component';
import { RelistStaffComponent } from './admin/relist-staff/relist-staff.component';
import { LabreportpdfComponent } from './labreportpdf/labreportpdf.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'patientlist', component: PatientlistComponent },
  { path: 'doctor', component: DoctorComponent },
  { path: 'labhome', component: LabHomeComponent, canActivate: [AuthGuard], data: { role: '3' } },
  { path: 'lab', component: LabTechnicianComponent, canActivate: [AuthGuard], data: { role: '3' } },
  { path: 'report', component: LabReportComponent, canActivate: [AuthGuard], data: { role: '3' } },
  { path: 'report/:LogId', component: LabReportComponent, canActivate: [AuthGuard], data: { role: '3' } },
  { path: 'generatedReport', component: GeneratedReportComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'frontoffice', component: FrontofficeComponent, canActivate: [AuthGuard], data: { role: '4' } },
  { path: 'addpatient', component: PatientComponent, canActivate: [AuthGuard], data: { role: '4' } },
  { path: 'addpatient/:patId', component: PatientComponent, canActivate: [AuthGuard], data: { role: '4' } },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'staff-list', component: StaffListComponent, canActivate: [AuthGuard], data: { role: '1' } },
  //{ path: 'add-staff/:UId', component: AddstaffComponent, canActivate: [AuthGuard], data: { role: '1' } },
  //{ path: 'add-staff/:Id', component: AddstaffComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'doctor-list', component: DoctorListComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'add-doctor/:UserId', component: AdddoctorComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'appointmentlist', component: AppointmentListComponent },
  { path: 'patientrecordform/:PatientId', component: PatientRecordFormComponent },
  { path: 'patientlog/:PatientId', component: PatientLogComponent, canActivate: [AuthGuard], data: { role: '2' } },
  { path: 'add-staff/:Id/:UId', component: AddstaffComponent },
  { path: 'add-doctor/:Id/:UId', component: AdddoctorComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'appointment/:PatientId', component: AppointmentComponent },
  { path: 'add-staff/:Id', component: AddstaffComponent },
  { path: 'add-doctor/:Id', component: AdddoctorComponent, canActivate: [AuthGuard], data: { role: '1' } },
  { path: 'patientlogform/:AppointmentId', component: PatientRecordFormComponent },
  { path: 'prescriptionmedicine/:LogId', component: PrescriptionMedicineComponent },
  { path: 'prescriptiontest/:LogId', component: PrescriptiontestComponent },
  { path: 'payment/:AId', component: PaymentComponent },
  { path: 'payment-list', component: ViewpaymentComponent },
  { path: 'add-user', component: AdduserComponent },
  { path: 'add-user/:userId', component: AdduserComponent },
  { path: 'user-list', component: UserListComponent },
  { path: 'addevent/:eveId', component: EventComponent },
  { path: 'payment', component: PaymentComponent },
  { path: 'addevent', component: EventComponent },
  { path: 'events', component: EventlistComponent },
  { path: 'payment-list', component: ViewpaymentComponent },
  { path: 'home', component: HomeComponent },
  { path: 'relist-staff', component: RelistStaffComponent },
  { path: 'reportpdf/:ReportId', component: LabreportpdfComponent }





]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


