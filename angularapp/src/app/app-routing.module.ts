import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { addpolicyComponent } from './addpolicy/addpolicy.component';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
import { SignupComponent } from './signup/signup.component';
import { UserNavComponent } from './user-nav/user-nav.component';
import { UserviewpolicyComponent } from './userviewpolicy/userviewpolicy.component';
import { LearnmoreComponent } from './learnmore/learnmore.component';
import { NavAdminComponent } from './nav-admin/nav-admin.component';
import { UserprofileComponent } from './userprofile/userprofile.component';

const routes: Routes = [
  {
  path : 'home' , component : HomeComponent
  },
  {
    path : 'about' , component : AboutComponent
  },
  {
    path : 'contact' , component : ContactComponent
  },
  {
    path:'login' , component :LoginComponent
  },
  {
path:'signup' , component:SignupComponent
  },
  {
    path:'addpolicy' , component : addpolicyComponent
  },
  {
    path:'policy-details', component : PolicyDetailsComponent
  },
 {
  path:'user-nav', component:UserNavComponent
 },
 {
  path:'userviewpolicy', component:UserviewpolicyComponent
 },
 {
  path:'learnmore', component:LearnmoreComponent
 },
 {
  path:'userprofile', component:UserprofileComponent
 },
 {
  path:'nav-admin', component:NavAdminComponent
 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
