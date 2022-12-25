import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-see-images',
  templateUrl: './see-images.component.html',
  styleUrls: ['./see-images.component.css']
})
export class SeeImagesComponent implements OnInit {

  constructor(private http: HttpClient, private router:Router) { }
  images:any
  ngOnInit(): void {
    this.http.get(`https://localhost:4300/Files`).subscribe(
      x=>{
       this.images=x
      }
    )
  }
  route():void{
    this.router.navigate(['/']);
   }
}
