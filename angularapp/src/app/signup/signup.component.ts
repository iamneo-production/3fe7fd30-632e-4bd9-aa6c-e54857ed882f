import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { RegisterService } from '../service/register.service';


export class RegisterModel {
  email!: string;
  password!: string;
  username!: string;
  mobilenumber: any;
  userrole!: string;
}
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  registerForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public registerservice: RegisterService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      mobilenumber: ['', Validators.required],
      userrole: ['', Validators.required]

    });
  }
  onSubmit(): void {
    if (this.registerForm.valid) {
      this.registerservice.Create(this.registerForm.value).subscribe(res=>{console.log(res)}); 
      this.registerForm.reset(); 
    } else {
      alert('Required is Empty');
    }
    
    
      
  }
}

