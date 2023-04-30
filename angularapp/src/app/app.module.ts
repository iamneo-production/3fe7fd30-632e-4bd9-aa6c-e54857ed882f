import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule, Route, Routes } from '@angular/router';
import { RouterOutlet} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AppComponent } from './app.component';

import { RegisterModel, SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';


import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {path:'',redirectTo:'user/login',pathMatch:'full'},
  { path: 'user/login', component:LoginComponent},

  { path: 'logout', component: LoginComponent },

  { path: 'user/signup', component:SignupComponent},
  {path:'home',component:HomeComponent}
  
  ];
@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    HomeComponent
    
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule,
    HttpClientModule,
    

  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
}
