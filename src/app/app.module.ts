import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { LabReportComponent } from './lab-report/lab-report.component';
import { FrontofficeComponent } from './frontoffice/frontoffice.component';
import { PatientComponent } from './frontoffice/patient/patient.component';
import { PatientlistComponent } from './frontoffice/patientlist/patientlist.component';
import { AppointmentComponent } from './frontoffice/appointment/appointment.component';

@NgModule({
  declarations: [
    AppComponent,
    LabTechnicianComponent,
    LabReportComponent,
    FrontofficeComponent,
    PatientComponent,
    PatientlistComponent,
    AppointmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
