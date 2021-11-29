import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LabReportComponent } from './lab-report/lab-report.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';

const routes: Routes = [
  {path:'lab',component:LabTechnicianComponent},
  {path:'report',component:LabReportComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
