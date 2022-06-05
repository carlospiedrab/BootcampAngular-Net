import { TestBed } from '@angular/core/testing';

import { AnimappService } from './animapp.service';

describe('AnimappService', () => {
  let service: AnimappService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AnimappService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
