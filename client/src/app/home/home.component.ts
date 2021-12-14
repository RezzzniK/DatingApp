import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  // users:any;//we dont using this because it was for the test
  constructor(/*private http:HttpClient*/) { }//we dont need http client because 
                                              //we dont getting any users from home component

  ngOnInit(): void {
    // this.getUsers();//we dont need it it was for showing favorite users
  }
  registerToggle(){
    this.registerMode=!this.registerMode;
  }
  // getUsers(){//we dont need it it was for showing favorite users
  //   this.http.get('https://localhost:5001/api/users').subscribe(users=>this.users=users);
  // }


  cancelRegisterMode(event:boolean){//function that called from html invoked by child 
    this.registerMode=event;        //cancelRegister output decorator
  }
}
