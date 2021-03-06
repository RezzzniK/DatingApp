import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from 'src/app/_models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl=environment.apiUrl;//variable from environment.ts

private currentSource=new ReplaySubject<User>(1);

currentUser$=this.currentSource.asObservable();

  constructor(private http:HttpClient) { }
  login(model:any){
    return this.http.post(this.baseUrl+'account/login',model).pipe(
      map((response:User)=>{
        const user=response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentSource.next(user);//adding to obervable next value of user
        }
      })
    )
  }
  setCurrentUser(user:User){
    this.currentSource.next(user);
  }
  logout(){
    localStorage.removeItem('user');
    this.currentSource.next(null);
  }

  register(model:any){
    return this.http.post(this.baseUrl+'account/register',model).pipe(
      map((user:User)=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentSource.next(user);    
        }
      }
    ));
  }
}
