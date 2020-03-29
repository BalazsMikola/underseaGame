import { TestBed } from '@angular/core/testing';

import { ServerAccessService } from './serverAccess.service';

describe('ServerAccessService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ServerAccessService = TestBed.get(ServerAccessService);
    expect(service).toBeTruthy();
  });
});
