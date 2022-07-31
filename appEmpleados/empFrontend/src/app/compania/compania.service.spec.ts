import { TestBed } from '@angular/core/testing';

import { CompaniaService } from './compania.service';

describe('CompaniaService', () => {
  let service: CompaniaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompaniaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
