import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLockerStatusComponent } from './user-locker-status.component';

describe('UserLockerStatusComponent', () => {
  let component: UserLockerStatusComponent;
  let fixture: ComponentFixture<UserLockerStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserLockerStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserLockerStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
