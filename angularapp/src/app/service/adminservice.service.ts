import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';  
import { PlanModel, addpolicyComponent } from '../addpolicy/addpolicy.component';


const URL: any = 'https://localhost:7188/api/Plan/AddPlan';

@Injectable({
  providedIn: 'root',
})
export class AdminserviceService {
url='https://localhost:7188/api/Plan/ReadAll';

  constructor(private http : HttpClient) { }

  Create(data:PlanModel):Observable<any> {
    return this.http.post(URL,data,{responseType : 'text'});
   }
    pol()
    {
      return this.http.get(this.url);
    }
    url1='https://localhost:7188/api/Plan/api/DeletePlan';
    delete(planId:number){

      return this.http.delete(`${this.url1}/${planId}`);
      
     }
     url3='https://localhost:7188/api/Plan/'
     edit(planId:number,data:any){
      return this.http.put(this.url3+'/UpdatePlan'+`/${planId}`,data);
    }

}


