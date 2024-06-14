import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';
import { Customers } from '../Classes/Customers';

@Component({
  selector: 'app-admin-approve',
  templateUrl: './admin-approve.component.html',
  styleUrls: ['./admin-approve.component.css']
})
export class AdminApproveComponent implements OnInit {
AllUser:Customers[]=[];
  constructor(private service:ServicesService, private router:Router) { }

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

  DeleteApprove(id:number){

  }
}
