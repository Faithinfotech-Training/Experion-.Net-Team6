import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PrescriptionService } from '../shared/prescription.service';

@Component({
  selector: 'app-prescription-medicine',
  templateUrl: './prescription-medicine.component.html',
  styleUrls: ['./prescription-medicine.component.css']
})
export class PrescriptionMedicineComponent implements OnInit {
  id: number;
  constructor(public route: ActivatedRoute, public prescription: PrescriptionService, public router: Router,private toasterService:ToastrService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['LogId'];
    this.prescription.medicineform.LogId = this.id;

  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    this.addMedicine(form);
    
    //insert

  }

  populateFormId(id: number) {
    console.log('POPULATING');
    this.prescription.testform.LogId = id;
  }
  addMedicine(form: NgForm) {
    console.log("Inserting a record...");
    console.log(form.value);
    this.prescription.AddMedicine(form.value).subscribe(
      (result) => {
        console.log(result);
        this.addTest(this.id);
        this.toasterService.success("Medicine added");
      }
    );
  }

  addTest(id: number) {
    console.log("Adding Test");
    console.log(id);
    this.populateFormId(id);
    this.router.navigate(['prescriptiontest', id]);
  }

}
