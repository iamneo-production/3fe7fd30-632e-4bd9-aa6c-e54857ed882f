

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import {HttpClient} from '@angular/common/http';




const URL:any='https://localhost:7188/api/Policy/Add';




@Injectable({

  providedIn: 'root'

})

export class UserprofileService {




constructor(private http:HttpClient) { }




Create(data:any):Observable<any>

 {

    return this.http.post(URL,data, {responseType : 'text'});

  }  

}






