import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ContactComponent } from './contact/contact.component';
import { GalleryComponent } from './gallery/gallery.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminLockerComponent } from './admin-locker/admin-locker.component';
import { AdminCustomerComponent } from './admin-customer/admin-customer.component';
import { AdminBranchComponent } from './admin-branch/admin-branch.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { AdminRequestComponent } from './admin-request/admin-request.component';
import { AdminApproveComponent } from './admin-approve/admin-approve.component';
import { UserLockerStatusComponent } from './user-locker-status/user-locker-status.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'Login',component:LoginComponent},
  {path:'Register',component:RegisterComponent},
  {path:'Contact',component:ContactComponent},
  {path:'Gallery',component:GalleryComponent},
  {path:'AdminHome',component:AdminHomeComponent},
  {path:'AdminLocker',component:AdminLockerComponent},
  {path:'AdminCustomer',component:AdminCustomerComponent},
  {path:'AdminBranch',component:AdminBranchComponent},
  {path:'UserHome',component:UserHomeComponent},
  {path:'AboutUs',component:AboutUsComponent},
  {path:'AdminRequest',component:AdminRequestComponent},
  {path:'AdminApprove',component:AdminApproveComponent},
  {path:'UserLockerStatus',component:UserLockerStatusComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
