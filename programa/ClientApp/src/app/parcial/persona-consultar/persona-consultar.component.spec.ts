import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaConsultarComponent } from './persona-consultar.component';

describe('PersonaConsultarComponent', () => {
  let component: PersonaConsultarComponent;
  let fixture: ComponentFixture<PersonaConsultarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonaConsultarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonaConsultarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
