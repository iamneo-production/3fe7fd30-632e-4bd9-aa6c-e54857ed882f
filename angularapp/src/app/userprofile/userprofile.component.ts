import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { UserprofileService } from '../services/userprofile.service';

export class PolicyModel{




  ApplicantName !: string;

  PolicyType !: string;

  ApplicantAddress !:string;

  ApplicantMobile !:string;

  ApplicantEmail !:string;

  ApplicantAadhaar!:string;

  ApplicantPan!:string;

  ApplicantSalary!:string;

}




@Component({

  selector: 'app-userprofile',

  templateUrl: './userprofile.component.html',

  styleUrls: ['./userprofile.component.css']

})

export class UserprofileComponent implements  OnInit {

  policyForm!:FormGroup;




  constructor(private formBuilder:FormBuilder,public userprofileservice:UserprofileService){}

    ngOnInit():void {

      this.policyForm = this.formBuilder.group({

ApplicantName:['',Validators.required],

  PolicyType: ['',Validators.required],

  ApplicantAddress:['',Validators.required],

  ApplicantMobile:['',Validators.required],

  ApplicantEmail:['',Validators.required],

  ApplicantAadhaar:['',Validators.required],

  ApplicantPan:['',Validators.required],

  ApplicantSalary:['',Validators.required]

      });

    }

    onSubmit(): void{

        if (this.policyForm.valid) {




              this.userprofileservice.Create(this.policyForm.value).subscribe((res) => {

          console.log("Welcome");
alert('Applied Successfully');
                console.log(res);

       

              });

         this.policyForm.reset();

       

            }else{

           alert('Specify the values');

      }

    }

   

}

   






