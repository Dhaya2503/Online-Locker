import { Component, OnInit } from '@angular/core';
import { Branchs } from '../Classes/Branchs';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-locker',
  templateUrl: './admin-locker.component.html',
  styleUrls: ['./admin-locker.component.css']
})
export class AdminLockerComponent implements OnInit {

  constructor(private service:ServicesService, private router:Router) { }

  ngOnInit(): void {}

  UpdateLocker(myform:any){
    let Branch:Branchs={
      branch_Id:0,
      branch_Name:myform.value.Branch_Name,
      state:myform.value.State,
      district:myform.value.District,
      total_locker:myform.value.Total_Locker,
      available_Locker:myform.value.Available_Locker
    }
    this.service.UpdateLockers(Branch).subscribe({
      next:(response)=>{this.router.navigate(['AdminBranch'])},
      error:(err)=>{console.log(err)}
    })
  }

}
