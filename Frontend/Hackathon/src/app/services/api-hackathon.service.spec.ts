import { TestBed } from '@angular/core/testing';

import { ApiHackathonService } from './api-hackathon.service';

describe('ApiHackathonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ApiHackathonService = TestBed.get(ApiHackathonService);
    expect(service).toBeTruthy();
  });
});
