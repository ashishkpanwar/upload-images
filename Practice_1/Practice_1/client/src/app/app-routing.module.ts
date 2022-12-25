import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SeeImagesComponent } from './see-images/see-images.component';
import { UploadImageComponent } from './upload-image/upload-image.component';

const routes: Routes = [
  { path: '', component: UploadImageComponent },
  { path: 'images', component: SeeImagesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
