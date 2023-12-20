import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KiegeszitokComponent } from './kiegeszitok.component';

describe('KiegeszitokComponent', () => {
  let component: KiegeszitokComponent;
  let fixture: ComponentFixture<KiegeszitokComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KiegeszitokComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KiegeszitokComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
