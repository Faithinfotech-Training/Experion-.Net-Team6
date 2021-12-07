import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { LabReportService } from '../shared/lab-report.service';
import { PatientlogService } from '../shared/patientlog.service';

@Component({
  selector: 'app-labreportpdf',
  templateUrl: './labreportpdf.component.html',
  styleUrls: ['./labreportpdf.component.css']
})
export class LabreportpdfComponent implements OnInit {

  constructor(public labreportservice:LabReportService,public route:ActivatedRoute) { }
  reportid:number;
  
  ngOnInit(): void {
    this.reportid=this.route.snapshot.params['ReportId'];
    this.labreportservice.getlabreportbyreportid(this.reportid);
  }
  captureScreen() {
    let data = document.getElementById('contentToConvert');
    html2canvas(data as any).then(canvas => {
        var imgWidth = 210;
        var pageHeight = 295;
        var imgHeight = canvas.height * imgWidth / canvas.width;
        var heightLeft = imgHeight;
        const contentDataURL = canvas.toDataURL('image/png');
        let pdfData = new jsPDF('p', 'mm', 'a4');
        var position = 0;
        pdfData.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
        pdfData.save(`Labreport` +this.reportid+ `.pdf`);
    });
}
}
