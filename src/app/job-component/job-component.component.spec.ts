import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobComponentComponent } from './job-component.component';

describe('JobComponentComponent', () => {
  let component: JobComponentComponent;
  let fixture: ComponentFixture<JobComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JobComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JobComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
