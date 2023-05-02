




import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';

import { RegisterService } from '../services/register.service';




export class RegisterModel {

  Email!: any;

  Password!: any;

  Username!: any;

  MobileNumber: any;

  UserRole!: any;

}

@Component({

  selector: 'app-signup',

  templateUrl: './signup.component.html',

  styleUrls: ['./signup.component.css']

})

export class SignupComponent implements OnInit {

  registerForm!: FormGroup;





  constructor(private formBuilder: FormBuilder, public registerservice:RegisterService) { }




  ngOnInit(): void {

    this.registerForm = this.formBuilder.group({

      Username: ['', Validators.required],

      Email: ['', [Validators.required, Validators.email]],

      Password: ['', [Validators.required]],

      MobileNumber: ['', Validators.required],

      UserRole: ['', Validators.required]




    });

  }

  onSubmit(): void {

    if (this.registerForm.valid) {

      this.registerservice.Create(this.registerForm.value).subscribe(res => { console.log(res) });
      alert("Reistration Successful")

      this.registerForm.reset();

    } else {

      alert('Required is Empty');

    }







  }

}






