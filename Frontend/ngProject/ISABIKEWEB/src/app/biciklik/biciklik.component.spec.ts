import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiciklikComponent } from './biciklik.component';

describe('BiciklikComponent', () => {
  let component: BiciklikComponent;
  let fixture: ComponentFixture<BiciklikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BiciklikComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BiciklikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
