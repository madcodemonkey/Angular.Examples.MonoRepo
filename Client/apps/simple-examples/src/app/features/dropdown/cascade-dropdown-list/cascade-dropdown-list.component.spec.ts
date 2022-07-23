import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CascadeDropdownListComponent } from './cascade-dropdown-list.component';

describe('CascadeDropdownListComponent', () => {
  let component: CascadeDropdownListComponent;
  let fixture: ComponentFixture<CascadeDropdownListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CascadeDropdownListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CascadeDropdownListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
