import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncativePostsComponent } from './incative-posts.component';

describe('IncativePostsComponent', () => {
  let component: IncativePostsComponent;
  let fixture: ComponentFixture<IncativePostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IncativePostsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IncativePostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
