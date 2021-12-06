import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabreportpdfComponent } from './labreportpdf.component';

describe('LabreportpdfComponent', () => {
  let component: LabreportpdfComponent;
  let fixture: ComponentFixture<LabreportpdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LabreportpdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabreportpdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
