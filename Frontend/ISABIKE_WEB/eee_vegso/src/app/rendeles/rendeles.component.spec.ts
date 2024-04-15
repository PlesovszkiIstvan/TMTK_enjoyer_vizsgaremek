import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RendelesComponent } from './rendeles.component';

describe('RendelesComponent', () => {
  let component: RendelesComponent;
  let fixture: ComponentFixture<RendelesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RendelesComponent]
    });
    fixture = TestBed.createComponent(RendelesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
