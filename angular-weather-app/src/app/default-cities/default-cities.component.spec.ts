import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultCitiesComponent } from './default-cities.component';

describe('DefaultCitiesComponent', () => {
  let component: DefaultCitiesComponent;
  let fixture: ComponentFixture<DefaultCitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DefaultCitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultCitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
