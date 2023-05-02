import { ComponentFixture, TestBed } from '@angular/core/testing';

import { addpolicyComponent } from './addpolicy.component';

describe('AddpolicyComponent', () => {
  let component: addpolicyComponent;
  let fixture: ComponentFixture<addpolicyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ addpolicyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(addpolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
