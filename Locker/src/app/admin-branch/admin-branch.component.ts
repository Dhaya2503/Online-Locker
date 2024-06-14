import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { Router } from '@angular/router';
import { Branchs } from '../Classes/Branchs';

@Component({
  selector: 'app-admin-branch',
  templateUrl: './admin-branch.component.html',
  styleUrls: ['./admin-branch.component.css']
})
export class AdminBranchComponent implements OnInit {

  Branch:Branchs[]=[];
  constructor(private service:ServicesService,private router:Router) { }

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
  }

  ngOnInit(): void {
    this.loaddata();
  }

  deleteBranch(branch_Id:number){
    this.service.deleteBranchs(branch_Id).subscribe({
      next:(response)=>{
           this.loaddata();
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
}
