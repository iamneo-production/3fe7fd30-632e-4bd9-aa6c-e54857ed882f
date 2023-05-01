import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AdminserviceService } from '../service/adminservice.service';
export class PlanModel {
  PolicyName!: string;
  ApplicableAge!: number;
  years!: number;
  claimamount!: number;
  InterestRate!: number;
}
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
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
  edit(): void {
    if (this.policyform.valid) {
    this.addpolicy.Create(this.policyform.value).subscribe(res => {
    console.log(res);
       });
      this.policyform.reset();
      }
      else {
      alert('Form should not be null'); }
        }


}
