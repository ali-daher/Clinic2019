import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssistantRegisterComponent } from './assistant-register.component';

describe('AssistantRegisterComponent', () => {
  let component: AssistantRegisterComponent;
  let fixture: ComponentFixture<AssistantRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssistantRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssistantRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
