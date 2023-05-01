import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { AdminserviceService } from '../service/adminservice.service';
export class PlanModel {
  PolicyName!: string;
  ApplicableAge!: number;
  years!: number;
  claimamount!: number;
  InterestRate!: number;
}
@Component({
  selector: 'app-addpolicy',
  templateUrl: './addpolicy.component.html',
  styleUrls: ['./addpolicy.component.css'],
})
export class addpolicyComponent implements OnInit {
  policyform!: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    public addpolicy: AdminserviceService
  ) { }
  ngOnInit() {

    this.policyform = this.formBuilder.group({
      PolicyName: ['', Validators.required],
      ApplicableAge: ['', Validators.required],
      years: ['', Validators.required],
      claimamount: ['', Validators.required],
      InterestRate: ['', Validators.required],
    });

  }
  onSubmit(): void {
    if (this.policyform.valid) {
      this.addpolicy.Create(this.policyform.value).subscribe((res) => {console.log("welcome");
        console.log(res);
      });
      this.policyform.reset();
    } 
    else {
    alert('Form should not be null');
   }
  }

}








