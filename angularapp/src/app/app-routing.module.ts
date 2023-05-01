import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { addpolicyComponent } from './addpolicy/addpolicy.component';
import { AdminComponent } from './admin/admin.component';
import { PolicyDetailsComponent } from './policy-details/policy-details.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  {
    path:'addpolicy',
    component:addpolicyComponent
  },
  {
    path:'admin',
    component:AdminComponent
  },
  {
    path:'policy-details',
    component:PolicyDetailsComponent
  },
  {
    path: 'updatePolicy',
    component:UpdateComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
