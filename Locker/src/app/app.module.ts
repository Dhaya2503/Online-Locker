import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ContactComponent } from './contact/contact.component';
import { GalleryComponent } from './gallery/gallery.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminLockerComponent } from './admin-locker/admin-locker.component';
import { AdminCustomerComponent } from './admin-customer/admin-customer.component';
import { AdminBranchComponent } from './admin-branch/admin-branch.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { AdminRequestComponent } from './admin-request/admin-request.component';
import { AdminApproveComponent } from './admin-approve/admin-approve.component';
import { UserLockerStatusComponent } from './user-locker-status/user-locker-status.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ContactComponent,
    GalleryComponent,
    AdminHomeComponent,
    AdminLockerComponent,
    AdminCustomerComponent,
    AdminBranchComponent,
    UserHomeComponent,
    AboutUsComponent,
    AdminRequestComponent,
    AdminApproveComponent,
    UserLockerStatusComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
