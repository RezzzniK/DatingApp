import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  baseUrl="https://localhost:5001/api/";//specifiyng URL from which we want to catch the exceptions
  validationErrors:string[]=[];//variable to passing validation errors, and init to empty arr
  /*ading to constructor http service so then we will be able to test
  exceptions comming from API*/
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  /*creating methods by types of errors*/
  get404Error(){
    this.http.get(this.baseUrl+'buggy/not-found')./*then we subscribe*/
    subscribe(/*then we check the response*/response=>{
      console.log(response);
    },error=>{
      console.log(error);
    })
  }
  get400Error(){
    this.http.get(this.baseUrl+'buggy/bad-request')./*then we subscribe*/
    subscribe(/*then we check the response*/response=>{
      console.log(response);
    },error=>{
      console.log(error);
    });
  }
  get500Error(){
    this.http.get(this.baseUrl+'buggy/server-error')./*then we subscribe*/
    subscribe(/*then we check the response*/response=>{
      console.log(response);
    },error=>{
      console.log(error);
    })
  }
  get401Error(){
    this.http.get(this.baseUrl+'buggy/auth')./*then we subscribe*/
    subscribe(/*then we check the response*/response=>{
      console.log(response);
    },error=>{
      console.log(error);
    })
  }
  get400ValidationError(){
    this.http.post(this.baseUrl+'account/register',{})./*then we subscribe*/
    subscribe(/*then we check the response*/response=>{
      console.log(response);
    },error=>{
      console.log(error);
      this.validationErrors=error;//adding the error information to validation error
    })
  }

}
