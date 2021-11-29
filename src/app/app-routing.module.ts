import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdddoctorComponent } from './admin/adddoctor/adddoctor.component';
import { AddstaffComponent } from './admin/addstaff/addstaff.component';
import { AdminComponent } from './admin/admin.component';
import { DoctorListComponent } from './admin/doctor-list/doctor-list.component';
import { StaffListComponent } from './admin/staff-list/staff-list.component';

const routes: Routes = [
  {path: 'admin', component: AdminComponent},
  {path: 'staff-list', component: StaffListComponent},
  {path: 'add-staff', component: AddstaffComponent},
  {path: 'doctor-list', component: DoctorListComponent},
  {path: 'add-doctor', component: AdddoctorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
