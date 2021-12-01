import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptionMedicineComponent } from './prescription-medicine.component';

describe('PrescriptionMedicineComponent', () => {
  let component: PrescriptionMedicineComponent;
  let fixture: ComponentFixture<PrescriptionMedicineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrescriptionMedicineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescriptionMedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
