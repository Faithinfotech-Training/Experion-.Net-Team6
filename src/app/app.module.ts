import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { LabReportComponent } from './lab-report/lab-report.component';
import { LoginComponent } from './login/login.component';
import { DoctorComponent } from './doctor/doctor.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DoctorComponent,
    LabTechnicianComponent,
    LabReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
