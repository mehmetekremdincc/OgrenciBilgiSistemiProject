import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItPortal } from './it-portal';

describe('ItPortal', () => {
  let component: ItPortal;
  let fixture: ComponentFixture<ItPortal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItPortal],
    }).compileComponents();

    fixture = TestBed.createComponent(ItPortal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
