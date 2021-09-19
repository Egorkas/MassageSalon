import { TestBed } from '@angular/core/testing';

import { MasseurService } from './masseur.service';

describe('MasseurService', () => {
  let service: MasseurService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MasseurService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
