import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelistStaffComponent } from './relist-staff.component';

describe('RelistStaffComponent', () => {
  let component: RelistStaffComponent;
  let fixture: ComponentFixture<RelistStaffComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelistStaffComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelistStaffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
