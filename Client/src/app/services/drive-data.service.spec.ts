import { TestBed } from '@angular/core/testing';

import { DriveDataService } from './drive-data.service';

describe('DriveDataService', () => {
  let service: DriveDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DriveDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
