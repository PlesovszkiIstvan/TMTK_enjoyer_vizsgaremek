import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SzervizComponent } from './szerviz.component';

describe('SzervizComponent', () => {
  let component: SzervizComponent;
  let fixture: ComponentFixture<SzervizComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SzervizComponent]
    });
    fixture = TestBed.createComponent(SzervizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
