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
import { LoginComponent } from './login/login.component';
import { AppointmentListComponent } from './appointment-list/appointment-list.component';
import { PatientLogComponent } from './patient-log/patient-log.component';
import { PatientRecordFormComponent } from './patient-record-form/patient-record-form.component';
import { AuthGuard } from './shared/auth.guard';
import{PrescriptionMedicineComponent} from '../app/prescription-medicine/prescription-medicine.component';
import { PrescriptiontestComponent } from '../app/prescriptiontest/prescriptiontest.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'doctor', component: DoctorComponent },
  { path: 'lab', component: LabTechnicianComponent },
  { path: 'report', component: LabReportComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'frontoffice', component: PatientlistComponent },
  { path: 'addpatient', component: PatientComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'staff-list', component: StaffListComponent,canActivate:[AuthGuard],data:{role:'1'}},
  { path: 'add-staff', component: AddstaffComponent,canActivate:[AuthGuard],data:{role:'1'} },
  {path: 'add-staff/:Id', component: AddstaffComponent},
  { path: 'doctor-list', component: DoctorListComponent,canActivate:[AuthGuard],data:{role:'1'} },
  { path: 'add-doctor', component: AdddoctorComponent,canActivate:[AuthGuard],data:{role:'1'} },
  { path: 'appointmentlist', component: AppointmentListComponent },
  { path: 'patientlog/:PatientId', component: PatientLogComponent },
  { path: 'patientlogform/:AppointmentId', component: PatientRecordFormComponent },
  {path:'lab',component:LabTechnicianComponent,canActivate:[AuthGuard],data:{role:'3'} },
  {path:'report',component:LabReportComponent,canActivate:[AuthGuard],data:{role:'3'} },
  {path:'report/:LogId',component:LabReportComponent,canActivate:[AuthGuard],data:{role:'3'} },
  {path:'appointment',component:AppointmentComponent,canActivate:[AuthGuard],data:{role:'2'} },
  {path:'frontoffice',component:PatientlistComponent,canActivate:[AuthGuard],data:{role:'2'} },
  {path:'prescriptionmedicine/:LogId',component:PrescriptionMedicineComponent},
  {path:'prescriptiontest/:LogId',component:PrescriptiontestComponent}


]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
