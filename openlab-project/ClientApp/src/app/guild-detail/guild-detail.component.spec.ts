import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuildDetailComponent } from './guild-detail.component';

describe('GuildDetailComponent', () => {
  let component: GuildDetailComponent;
  let fixture: ComponentFixture<GuildDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GuildDetailComponent]
    });
    fixture = TestBed.createComponent(GuildDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
