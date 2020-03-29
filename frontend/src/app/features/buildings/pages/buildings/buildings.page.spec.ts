import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildingsPage } from './buildings.page';

describe('BuildingsComponent', () => {
  let component: BuildingsPage;
  let fixture: ComponentFixture<BuildingsPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuildingsPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuildingsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
