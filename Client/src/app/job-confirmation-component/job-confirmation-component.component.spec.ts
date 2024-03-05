import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobConfirmationComponentComponent } from './job-confirmation-component.component';

describe('JobConfirmationComponentComponent', () => {
  let component: JobConfirmationComponentComponent;
  let fixture: ComponentFixture<JobConfirmationComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JobConfirmationComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobConfirmationComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
