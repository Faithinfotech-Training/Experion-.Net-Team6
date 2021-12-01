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
import { FrontofficeComponent } from './frontoffice/frontoffice.component';
import { AuthGuard } from './shared/auth.guard';
import { PatientLogComponent } from './patient-log/patient-log.component';

const routes: Routes = [
  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'patientlist',component:PatientlistComponent},
  {path:'doctor',component:DoctorComponent},
  {path:'lab',component:LabTechnicianComponent,canActivate:[AuthGuard],data:{role:'3'} },
  {path:'report',component:LabReportComponent},
  {path:'report/:LogId',component:LabReportComponent,canActivate:[AuthGuard],data:{role:'3'} },
  {path:'appointment',component:AppointmentComponent },
  {path:'frontoffice',component:FrontofficeComponent ,canActivate:[AuthGuard],data:{role:'2'} },
  {path:'addpatient',component:PatientComponent,canActivate:[AuthGuard],data:{role:'2'} },
  {path: 'admin', component: AdminComponent,canActivate:[AuthGuard],data:{role:'1'} },
  {path: 'staff-list', component: StaffListComponent},
  {path: 'add-staff', component: AddstaffComponent},
  {path: 'doctor-list', component: DoctorListComponent},
  {path: 'add-doctor', component: AdddoctorComponent},
 {path:'appointmentlist',component:AppointmentListComponent},
 {path:'patientlog/:PatientId',component:PatientLogComponent}

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
