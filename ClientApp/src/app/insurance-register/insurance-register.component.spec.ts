import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceRegisterComponent } from './insurance-register.component';

describe('InsuranceRegisterComponent', () => {
  let component: InsuranceRegisterComponent;
  let fixture: ComponentFixture<InsuranceRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsuranceRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsuranceRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
