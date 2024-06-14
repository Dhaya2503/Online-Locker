import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from '../Classes/Customers';
import { ServicesService } from '../services.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private service:ServicesService,private router:Router) { }

  ngOnInit(): void {
   
  }

  AddUser(myform:any){
    let Customer:Customers={
      user_Id:0,
      name:myform.value.Name,
      email:myform.value.Email,
      phone:myform.value.Phone,
      state:myform.value.State,
      district:myform.value.District,
      password:myform.value.Password,
      locker_Status:false,

    }
    this.service.AddUsers(Customer).subscribe({
      next:(response)=>{this.router.navigate(['Login'])},
      error:(response)=>{console.log(response)}
    });
  }

  

}
