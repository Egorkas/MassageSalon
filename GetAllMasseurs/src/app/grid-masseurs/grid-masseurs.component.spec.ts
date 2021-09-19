import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridMasseursComponent } from './grid-masseurs.component';

describe('GridMasseursComponent', () => {
  let component: GridMasseursComponent;
  let fixture: ComponentFixture<GridMasseursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GridMasseursComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GridMasseursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
