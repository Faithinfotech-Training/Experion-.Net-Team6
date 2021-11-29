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

const routes: Routes = [
  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'doctor',component:DoctorComponent},
  {path:'lab',component:LabTechnicianComponent},
  {path:'report',component:LabReportComponent},
  {path:'appointment',component:AppointmentComponent},
  {path:'frontoffice',component:PatientlistComponent},
  {path:'patient',component:PatientComponent},
  {path: 'admin', component: AdminComponent},
  {path: 'staff-list', component: StaffListComponent},
  {path: 'add-staff', component: AddstaffComponent},
  {path: 'doctor-list', component: DoctorListComponent},
  {path: 'add-doctor', component: AdddoctorComponent}


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
