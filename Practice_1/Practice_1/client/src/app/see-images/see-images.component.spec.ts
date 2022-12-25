import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeeImagesComponent } from './see-images.component';

describe('SeeImagesComponent', () => {
  let component: SeeImagesComponent;
  let fixture: ComponentFixture<SeeImagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeeImagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeeImagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
