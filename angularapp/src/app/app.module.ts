import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavAdminComponent } from './nav-admin/nav-admin.component';
import { addpolicyComponent } from './addpolicy/addpolicy.component';
import {HttpClientModule} from '@angular/common/http';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
//import { NgFor } from '@angular/common';
import { UpdateComponent } from './update/update.component';


@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    NavAdminComponent,
    addpolicyComponent,
    PolicyDetailsComponent,
    UpdateComponent,
   
  
    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
