import { TestBed } from '@angular/core/testing';

import { LabListService } from './lab-list.service';

describe('LabListService', () => {
  let service: LabListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
