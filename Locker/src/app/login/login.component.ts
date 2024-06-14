import { ServicesService } from './../services.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customers } from '../Classes/Customers';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
user:string[]=[];
Customer:Customers[]=[];

  constructor(private service:ServicesService,private router:Router) { }

  ngOnInit(): void {
    this.service.getAllCustomers().subscribe({
      next:(response)=>{
        this.Customer=response;
        console.log(response);
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
  addvalidation(myform:any){
    let newlogin:Customers={
      user_Id:0,
      name:"",
      email:myform.value.Email1,
      phone:0,
      state:"",
      district:"",
      password:myform.value.Password1,
      locker_Status:false,
    }
    if(newlogin.email=="Admin" && newlogin.password=="Admin@123"){
      this.router.navigate(['AdminHome']);
   
    }
    else{
    this.service.validateUser(newlogin.email, newlogin.password).subscribe(isValid => {
      if (isValid) {
        console.log(this.Customer);
        let userdet = this.Customer.find(item => {return item.email == newlogin.email && item.password == newlogin.password;});

if (userdet) {
  this.service.saveUser(userdet);
  // Redirect to a protected route after successful login
  this.router.navigate(['UserHome']);
} else {
  console.error("User not found or incorrect credentials");
}


        // Login successful
        //let userdet = this.Customer.find(item=>{return item.email==newlogin.email && item.password==newlogin.password})
        //console.log(userdet);
        // localStorage.setItem("email",newlogin.email);
        // localStorage.setItem("password",newlogin.password)
        //localStorage.setItem("currentuser",JSON.stringify(userdet));
        console.log(localStorage);
        this.router.navigate(['UserHome'])
        // Implement your login success logic here
      } else {
        // Login failed
        //this.router.navigate(['Login'])
        this.errormessage();
        // Implement your login failure logic here
      }
    });}
  }

  

  errormessage(){
    alert("Invalid username or Password");
  }


}
