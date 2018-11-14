import { TestBed, inject } from '@angular/core/testing';

import { StudentsLsService } from './students-ls.service';

describe('StudentsLsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StudentsLsService]
    });
  });

  it('should be created', inject([StudentsLsService], (service: StudentsLsService) => {
    expect(service).toBeTruthy();
  }));
});
