import { Component, OnInit } from '@angular/core';
import { Customers } from '../Classes/Customers';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-admin-customer',
  templateUrl: './admin-customer.component.html',
  styleUrls: ['./admin-customer.component.css']
})
export class AdminCustomerComponent implements OnInit {
AllUser:Customers[]=[];
  constructor(private service:ServicesService,private router:Router) { }

  loaddata(){
    this.service.getAllCustomers().subscribe({
      next:(response)=>{
        this.AllUser=response;
        console.log(response);
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
  ngOnInit(): void {
    this.loaddata();
  }

  deleteUser(user_Id:number){
    this.service.deleteUsers(user_Id).subscribe({
      next:(response)=>{
           this.loaddata();
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
}
