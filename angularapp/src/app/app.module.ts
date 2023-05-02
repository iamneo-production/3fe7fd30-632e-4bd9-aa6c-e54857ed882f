import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { NavComponent } from './nav/nav.component';
import { NgModule } from '@angular/core';
import {  FormsModule, NgForm } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { RouterOutlet} from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { SignupComponent } from './signup/signup.component';
import { addpolicyComponent } from './addpolicy/addpolicy.component';
import { UpdateComponent } from './update/update.component';
import { AdminComponent } from './admin/admin.component';
import { NavAdminComponent } from './nav-admin/nav-admin.component';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
//import { NgFor } from '@angular/common';
import { UserprofileComponent } from './userprofile/userprofile.component';



const routes: Routes = [
  {path:'',redirectTo:'user/login',pathMatch:'full'},
  { path: 'user/login', component:LoginComponent},

  { path: 'logout', component: LoginComponent },

  {path:'user/signup', component: SignupComponent},
  {path:'nav-admin',component:NavAdminComponent}

  //{ path: 'user/signup', component:SignupComponent},
  
  ];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    LoginComponent,
    NavComponent,
    AboutusComponent,
    UserprofileComponent,
    SignupComponent,
    addpolicyComponent,
    UpdateComponent,
    AdminComponent,
    NavAdminComponent,
    PolicyDetailsComponent,
    

  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule,
    HttpClientModule,
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
