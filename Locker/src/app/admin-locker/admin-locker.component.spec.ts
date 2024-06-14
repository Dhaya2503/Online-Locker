import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLockerComponent } from './admin-locker.component';

describe('AdminLockerComponent', () => {
  let component: AdminLockerComponent;
  let fixture: ComponentFixture<AdminLockerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminLockerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminLockerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
