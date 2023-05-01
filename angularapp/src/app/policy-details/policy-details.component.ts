import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminserviceService } from '../service/adminservice.service';
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
policy : any
constructor(private userdata:AdminserviceService){
  userdata.pol().subscribe((data)=>{
console.log(data);
this.policy=data;
}
);
}
delete(PlanId:number){
window.location.reload();
console.log(PlanId);
this.userdata.delete(PlanId).subscribe((result)=>{
console.warn(result);
});
}
}
