import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminaddpolicyComponent } from './adminaddpolicy.component';

describe('AdminaddpolicyComponent', () => {
  let component: AdminaddpolicyComponent;
  let fixture: ComponentFixture<AdminaddpolicyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminaddpolicyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminaddpolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
