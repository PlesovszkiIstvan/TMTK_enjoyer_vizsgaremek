import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserRendelesComponent } from './user-rendeles.component';

describe('UserRendelesComponent', () => {
  let component: UserRendelesComponent;
  let fixture: ComponentFixture<UserRendelesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserRendelesComponent]
    });
    fixture = TestBed.createComponent(UserRendelesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
