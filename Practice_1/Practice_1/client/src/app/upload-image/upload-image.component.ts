import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent implements OnInit {

  userForm: FormGroup;
  submitted = false;  
  file: File = null;
  isLoading: boolean;
  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router
  ) {
  }
  ngOnInit(): void {
    this.userForm = this.formBuilder.group(
      {
        fileName: new FormControl('', Validators.required),
        newFileUpload: new FormControl('', Validators.required)
      }
    );
  }
  get f() {
    return this.userForm.controls;
  }
  handleFileInput(event) {
    var infoArea = document.getElementById('file-upload-filename');
    this.file = event.target.files[0];
    var input = event.srcElement;
    var fileName = input.files[0].name;
  }
  saveFile() {
    this.isLoading = true
    this.submitted = true;
    if (this.userForm.invalid) {
      return;
    }
    const formData = new FormData();
    formData.append("file", this.file, this.file.name);
    formData.append("fileName", this.f.fileName.value);
    this.http.post(`https://localhost:4300/Files`, formData).subscribe(
      {
        next: resposne => {
          alert("Image Added")
        },
        error: (error) => {
          alert("Some error happened, please try again")
        }
      }
    )
    this.isLoading = false
  }
  route():void{
    this.router.navigate(['/images']);
   }

}
