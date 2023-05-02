import { Component } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AdminserviceService } from '../services/adminservice.service';
@Component({
    selector: 'app-policy-details',

  templateUrl: './policy-details.component.html',

  styleUrls: ['./policy-details.component.css']

})

export class PolicyDetailsComponent {

  PlanId!: number;

  PolicyName!: string;

  ApplicableAge!: number;

  years!: number;

  claimamount!: number;

  InterestRate!: number;
policy : any[] =[]

constructor(private userdata:AdminserviceService){
userdata.pol().subscribe((data)=>{

console.log(data);
var js=JSON.stringify(data);
var jp= JSON.parse(js);
this.policy=jp.response.users;
});
}
delete(PlanId:number){
    console.log(PlanId);
    console.log("delete this");
this.userdata.delete(PlanId).subscribe((result)=>{
console.warn(result);
});
window.location.reload();

}
}






