
import { Branchs } from './../Classes/Branchs';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customers } from '../Classes/Customers';
import { ServicesService } from '../services.service';
import { Requests } from '../Classes/Requests';

@Component({
  selector: 'app-admin-request',
  templateUrl: './admin-request.component.html',
  styleUrls: ['./admin-request.component.css']
})
export class AdminRequestComponent implements OnInit {

  mail:string='';
  branch:string='';
  Branch:Branchs[]=[];
  Customer:Customers[]=[];
  Request:Requests[]=[];
  constructor(private route:ActivatedRoute,private service:ServicesService,private router:Router) { }

  ngOnInit(): void {
    this.service.getAllRequests().subscribe({
      next:(response)=>{
        this.Request=response;
        console.log(response);
      },
      error:(err)=>{
        console.log(err);
      }
    })

    this.service.getAllCustomers().subscribe({
      next:(response)=>{
        this.Customer=response;
        console.log(response);
      },
      error:(err)=>{
        console.log(err);
      }
    })

    this.service.getAllBranchs().subscribe({
      next:(response)=>{
        this.Branch=response;
        console.log(response);
      },
      error:(err)=>{
        console.log(err);
      }
    })
    // get request from database and show in frontend
  }

  Approve(us:Requests){
    let cust=this.Customer.filter(item=>{return item.user_Id==us.user_Id})
    let bran=this.Branch.filter(item=>{return item.branch_Id==us.branch_Id})

    let UpdatedCustomer:Customers={
      user_Id: cust[0].user_Id,
    name:cust[0].name,
    email:cust[0].email,
    phone:cust[0].phone,
    state:cust[0].state,
    district:cust[0].district,
    password:cust[0].password,
    locker_Status:true
    }

    this.service.UpdateCustomers(UpdatedCustomer).subscribe({
      next:(response)=>{},
      error:(response)=>{console.log(response)}
    });

    let UpdatedBranch:Branchs={
      branch_Id:bran[0].branch_Id,
      branch_Name:bran[0].branch_Name,
      state:bran[0].state,
      district:bran[0].district,
      total_locker:bran[0].total_locker,
      available_Locker:bran[0].available_Locker-1
    }

    this.service.UpdateBranchs(UpdatedBranch).subscribe({
      next:(response)=>{},
      error:(response)=>{console.log(response)}
    });

    this.service.deleteRequests(us.request_Id).subscribe({
      next:(response)=>{alert("Request Approved !")},
      error:(response)=>{console.log(response)}
    });

  }

  Reject(us:Requests){
    this.service.deleteRequests(us.request_Id).subscribe({
      next:(response)=>{alert("Request Rejected !")},
      error:(response)=>{console.log(response)}
    });
  }



// Approve(req: Requests) {
//   let cust = this.Customer.filter....
//   let updatedCustomer : Customer = {
//     user_id = cust[0].user_id;
//     ....
//     locker_status = true
//   }
  //this.service put customer
  //------------------
  //this.service get all branches
  //filter branch by branch id
  // update branch avail - 1
  // this.service put branch
  //-------------------------
  //this.service delete by request id 
  //----------------------------
  //alert "request approved"
// }



}
