import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorComponent } from './doctor/doctor.component';
import { LabReportComponent } from './lab-report/lab-report.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'doctor',component:DoctorComponent},
  {path:'lab',component:LabTechnicianComponent},
  {path:'report',component:LabReportComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
