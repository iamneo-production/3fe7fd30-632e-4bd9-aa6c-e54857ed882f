import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmineditappliedpolicyComponent } from './admineditappliedpolicy.component';

describe('AdmineditappliedpolicyComponent', () => {
  let component: AdmineditappliedpolicyComponent;
  let fixture: ComponentFixture<AdmineditappliedpolicyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdmineditappliedpolicyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdmineditappliedpolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
