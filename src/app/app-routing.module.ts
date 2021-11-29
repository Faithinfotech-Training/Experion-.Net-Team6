import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentComponent } from './frontoffice/appointment/appointment.component';
import { PatientComponent } from './frontoffice/patient/patient.component';
import { PatientlistComponent } from './frontoffice/patientlist/patientlist.component';
import { LabReportComponent } from './lab-report/lab-report.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';

const routes: Routes = [
  {path:'lab',component:LabTechnicianComponent},
  {path:'report',component:LabReportComponent},
  {path:'appointment',component:AppointmentComponent},
  {path:'frontoffice',component:PatientlistComponent},
  {path:'patient',component:PatientComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
