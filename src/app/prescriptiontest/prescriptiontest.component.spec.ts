import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescriptiontestComponent } from './prescriptiontest.component';

describe('PrescriptiontestComponent', () => {
  let component: PrescriptiontestComponent;
  let fixture: ComponentFixture<PrescriptiontestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrescriptiontestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescriptiontestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
