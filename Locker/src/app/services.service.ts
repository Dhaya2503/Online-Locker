import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customers } from './Classes/Customers';
import { Branchs } from './Classes/Branchs';
import { map } from 'rxjs/operators';
import { Requests } from './Classes/Requests';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
Loggedin_User:any;
id:number=0;

  CustomerUrl: string ='https://localhost:7002/api/Customer_Detail'
  LockerUrl:string='https://localhost:7002/api/Branch_Detail'
  RequestUrl:string='https://localhost:7002/api/Requested_Locker'

  constructor(private http: HttpClient) { }

  private readonly CURRENT_USER_KEY = 'currentuser';

  saveUser(user: any): void {
    localStorage.setItem(this.CURRENT_USER_KEY, JSON.stringify(user));
  } 

  getUser(): any {
    const userString = localStorage.getItem(this.CURRENT_USER_KEY);
    return userString ? JSON.parse(userString) : null;
  }

  removeUser(): void {
    localStorage.removeItem(this.CURRENT_USER_KEY);
  }


  getAllCustomers():Observable<Customers[]>{
    return this.http.get<Customers[]>(this.CustomerUrl);
  }

  getAllBranchs():Observable<Branchs[]>{
    return this.http.get<Branchs[]>(this.LockerUrl);
  }

  getAllRequests():Observable<Requests[]>{
    return this.http.get<Requests[]>(this.RequestUrl);
  }

  getCustomerById(id:number):Observable<any>{
    return this.http.get<any>(this.CustomerUrl+'/'+id);
  } 

  AddUsers(Customer:Customers):Observable<Customers>{
    //Customer.Locker_Status=false;
    return this.http.post<Customers>(this.CustomerUrl,Customer)
  }

  AddRequests(Request:Requests):Observable<Requests>{
    return this.http.post<Requests>(this.RequestUrl,Request);
  }

  UpdateLockers(Branch:Branchs):Observable<Branchs>{
    return this.http.post<Branchs>(this.LockerUrl,Branch);
  }

  UpdateCustomers(Customer:Customers):Observable<void>{
    return this.http.put<void>(this.CustomerUrl+'/'+Customer.user_Id,Customer);
  }

  UpdateBranchs(Branch:Branchs):Observable<void>{
    return this.http.put<void>(this.LockerUrl+'/'+Branch.branch_Id,Branch);
  }

  validateUser(username: string, password: string): Observable<boolean> {
    this.Loggedin_User = username;

    return this.getAllCustomers().pipe(
      map(users => {
        const user = users.find(u => u.email === username && u.password === password);
        return !!user;
      })
    );
  }

  deleteUsers(user_Id:number):Observable<void>{
    return this.http.delete<void>(this.CustomerUrl+'/'+user_Id);
  }

  deleteBranchs(branch_Id:number):Observable<void>{
    return this.http.delete<void>(this.LockerUrl+'/'+branch_Id);
  }

  deleteRequests(Request_Id:number):Observable<void>{
    return this.http.delete<void>(this.RequestUrl+'/'+Request_Id);
  }

  SetId(id:number){
    this.id=id;
  }
  GetId(){
    return this.id;
  }
}
