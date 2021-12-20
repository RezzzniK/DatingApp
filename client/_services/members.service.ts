import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { environment } from 'src/environments/environment';

// /*we need to add authentification headers options because we have specified it in api */
// const httpOptions={
//   headers:new HttpHeaders({
//     Authorization: 'Bearer '+JSON.parse(localStorage.getItem('user'))?.token
//   })
// }

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  //getting baseUrl from environment.ts
  baseUrl=environment.apiUrl;

  constructor(/*adding http client for our constructor*/private http:HttpClient) { }
    /*here we going to create our 2 methods */
    getMembers(){
      return this.http.get<Member[]>(this.baseUrl+'users');
    }
    getMember(username:string){
      return this.http.get<Member>(this.baseUrl+'users/'+username);
    }
  
}
