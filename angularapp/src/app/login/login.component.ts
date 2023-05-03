import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

import { from } from 'rxjs';
import { Route, Router, RouterModule, Routes } from '@angular/router';
import { LoginService } from '../service/login.service';
export class LoginModel {
  Email !: any;
  Password !: any;
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  login: LoginModel = new LoginModel();
  constructor(private loginservice: LoginService, public router:Router) { }
  onSubmit(userForm: NgForm) {
    

    if (!userForm.valid) {

      alert("enter valid email address");

    }

    if (userForm.valid) {



      console.log(userForm.value);

      this.loginservice.Create(userForm.value).subscribe(res => {

        // console.log(res);

        var str = JSON.stringify(res)

        // console.log(str);

        var r = JSON.parse(str)

        if (r.errorMessage == 'No user found with username') {

          alert("no such user found");

          userForm.resetForm();

        }

        else {

          var role = this.loginservice.settoken(r.message)

          //alert("login successful");

          role = role.toLowerCase();

          if (role == "admin") {

            this.router.navigateByUrl('home');

          }

          else {

            this.router.navigateByUrl('user/home');

          }



          userForm.resetForm();



        }







      });



    }
  }
}
