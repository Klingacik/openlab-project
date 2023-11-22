import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuildJoinComponent } from './guild-join.component';

describe('GuildJoinComponent', () => {
  let component: GuildJoinComponent;
  let fixture: ComponentFixture<GuildJoinComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GuildJoinComponent]
    });
    fixture = TestBed.createComponent(GuildJoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
