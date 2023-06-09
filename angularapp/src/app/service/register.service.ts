import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterModel } from 'src/app/signup/signup.component';

const URL:any="https://8080-fedccdebddefacccdadbfdddccffdce.project.examly.io/api/Auth/Register";
@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  
  constructor(private http:HttpClient) { }
  Create(data:RegisterModel) : Observable<any>
  {
    return this.http.post<RegisterModel>(URL,data);
  }
  
}
