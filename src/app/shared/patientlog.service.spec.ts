import { TestBed } from '@angular/core/testing';

import { PatientlogService } from './patientlog.service';

describe('PatientlogService', () => {
  let service: PatientlogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientlogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
