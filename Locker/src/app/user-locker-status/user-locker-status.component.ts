import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Customers } from '../Classes/Customers';

@Component({
  selector: 'app-user-locker-status',
  templateUrl: './user-locker-status.component.html',
  styleUrls: ['./user-locker-status.component.css']
})
export class UserLockerStatusComponent implements OnInit {
  id:number=0;
  Fetcheduser:any={
    user_Id:0,
    name:"",
    email:"",
    phone:0,
    state:"",
    district:"",
    password:"",
    locker_Status:false}
  ;
  constructor(private service:ServicesService, private route:Router, private router:ActivatedRoute) { }

  ngOnInit(): void {
     this.id=this.service.GetId();
     if(this.id!=0)
      {
        console.log("id="+this.id)
     this.service.getCustomerById(+this.id).subscribe({
      next:(response)=>{this.Fetcheduser=response;console.log(this.Fetcheduser)},
      error:(err)=>console.log(err)
    })
  }
  }

}
