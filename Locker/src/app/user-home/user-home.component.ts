import { Customers } from './../Classes/Customers';
import { Component, OnInit } from '@angular/core';
import { Branchs } from '../Classes/Branchs';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';
import { Requests } from '../Classes/Requests';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {


  result:any;
  userdet:any;
  user:string='';
  Branch:Branchs[]=[];
  Customer:Customers[]=[];
  Fetcheduser:Customers[]=[];

  uniquestates:string[]=[];
  uniquedistrict:string[]=[];
  uniquebranch:string[]=[];

  selectedState: string = 'Select';
  selectedDistrict: string = 'Select';
  selectedBranch:string='Select';
  
  constructor(private service:ServicesService,private router:Router) {}
   

  loaddata(){
    this.service.getAllBranchs().subscribe({
      next:(response)=>{
        this.Branch=response;
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
  }


  ngOnInit(): void {
    this.loaddata();
    this.uniquestates = [...new Set(this.Branch.map(item => item.state))];
    this.user=this.service.Loggedin_User;
    console.log(this.user)

  }
  
  DisplayLocker(myform2:any){
    
    let selected=myform2.value.Se_Branch;
    let result = this.Branch.find(item=> {return item.branch_Name == selected})


    this.user=this.service.Loggedin_User;
    console.log(this.user)
    let userdet = this.Customer.find(item=>{return item.email==this.user})
    console.log(userdet?.name);

  console.log(result?.available_Locker);
  // this.userdet=userdet?.user_Id;
  

  if(result?.available_Locker == 0) {
    //alert("No Lockers Available!");
    this.result = result?.available_Locker;
  } else {
    this.result = result?.available_Locker;
  //alert("Available Lockers : " + this.result?.available_Locker);
  }
  }

  onStateChange(state: string) {
    this.selectedState=state;
    this.uniquedistrict = [...new Set(this.Branch.filter(item => item.state === state).map(item => item.district))];
    this.selectedDistrict = state;
    this.uniquebranch = [];
    console.log(this.uniquedistrict);
  }

  onDistrictChange(district: string) {
    this.selectedDistrict=district;
    this.uniquebranch = this.Branch.filter(item => item.district == district && item.state == this.selectedState).map(item => item.branch_Name);
    console.log(this.uniquebranch);
  }

  onBranchChange(branch:string){
this.selectedBranch=branch;
  }

  request() {
    this.uniquestates = [...new Set(this.Branch.map(item => item.state))];
    // this.uniquedistrict= [...new Set(this.Branch.map(item => item.district))];
  }

  redirect(mail:string,branch:string){

    let cust = this.Customer.filter(item=>{return item.email==mail});
    let bran = this.Branch.filter(item=>{return item.branch_Name==branch})
    let request:Requests={
      request_Id:0,
      user_Id:cust[0]?.user_Id,
      user_Name:cust[0]?.name,
      user_Email:cust[0].email,
      branch_Id:bran[0].branch_Id,
      branch_Name:bran[0].branch_Name
    }
    this.service.AddRequests(request).subscribe({
      next:(response)=>{alert("Request Send For Approval!");},
      error:(response)=>{console.log(response)}
    });
  }


  GetUserbyId(mail:string){
    
    let cust = this.Customer.filter(item=>{return item.email==mail});
    let id=cust[0].user_Id;
    console.log(id);
    this.service.SetId(id);
if(id!=0){
  console.log(id)
     this.service.getCustomerById(+id).subscribe({
      next:(response)=>{this.Fetcheduser=response; },
      error:(err)=>console.log(err)
    })

    console.log(this.Fetcheduser);
    this.router.navigate(['UserLockerStatus']);
  }
  }
}
