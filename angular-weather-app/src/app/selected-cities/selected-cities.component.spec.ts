import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedCitiesComponent } from './selected-cities.component';

describe('SelectedCitiesComponent', () => {
  let component: SelectedCitiesComponent;
  let fixture: ComponentFixture<SelectedCitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectedCitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedCitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
