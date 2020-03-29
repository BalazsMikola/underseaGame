import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttackPage } from './attack.page';

describe('AttackPage', () => {
  let component: AttackPage;
  let fixture: ComponentFixture<AttackPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttackPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttackPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
