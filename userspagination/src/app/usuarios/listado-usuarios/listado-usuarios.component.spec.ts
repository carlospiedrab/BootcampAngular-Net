import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoUsuariosComponent } from './listado-usuarios.component';

describe('ListadoUsuariosComponent', () => {
  let component: ListadoUsuariosComponent;
  let fixture: ComponentFixture<ListadoUsuariosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadoUsuariosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadoUsuariosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
