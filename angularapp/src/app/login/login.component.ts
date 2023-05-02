import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { NgModel } from '@angular/forms';
import { Loginservice } from '../services/login.service';
import { from } from 'rxjs';
import { Route, Router, RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
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
userform: any;
constructor(private loginservice :Loginservice,private router:Router) {}
  onSubmit(userForm: NgForm) {
    if (!userForm.valid) {
      alert("enter valid email address");
    }

    if (userForm.valid) {
      console.log(userForm.value);
      this.loginservice.Create(userForm.value).subscribe((res: any) => {
        var str = JSON.stringify(res)
        
        var r = JSON.parse(str)
        if (r.errorMessage == 'No user found with username') 
        {
          alert("no such user found");
          userForm.resetForm();
        }


        else 
        {
          var role = this.loginservice.settoken(r.message)
          alert("login successful");
          console.log(role);
          //role = role.toLowerCase();

          if (role == "admin" ) 
          {
            console.log(role);
            this.router.navigateByUrl('nav-admin');
          }

          else 
          {
            console.log(role);
            this.router.navigateByUrl('user-nav');
          }






          userForm.resetForm();






        }










      });






    }

  }

}





//export { Loginservice };

