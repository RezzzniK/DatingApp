import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '_services/account.service';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any={};
  //loggedIn:boolean;
  //we don't need cuurentUser$ because we alrady have that in account services
  //currentUser$:Observable<User>;//makin data type to store our user
  constructor(/*private we will change it to public to
    make this be accessble from all parts of nav component*/
    public accountService:AccountService,private toastr:ToastrService,private router:Router) { }

  ngOnInit(): void {
    //this.getCurrentUser(); instead of this function we will get our user from account service
   // this.currentUser$=this.accountService.currentUser$; we will get it from account services

    
  }
  login()
  {
    this.accountService.login(this.model).subscribe(response=>{
      this.router.navigateByUrl('/members'); 
      //console.log(response)
      //this.loggedIn=true;
     });//,
    //   error=>{
    //       // console.log(error);
    //       // this.toastr.error(error.error);
    // });
      
  } 

   logout(){
    this.accountService.logout();
    //this.loggedIn=false;
     
   }
   //we dont need this method anymore becouse we getting our user straight from 
   //account service
  /* getCurrentUser(){
     this.accountService.currentUser$.subscribe(user=>{
       this.loggedIn=!!user;
     },error=>{
       console.log(error);
     })
   }*/
  }




