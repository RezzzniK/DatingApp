import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  //@Input() usersFromHomeComponent:any={};//function Input [decorator] will bring us 
                                             //data from home.component.ts 
  @Output() cancelRegister=new EventEmitter();   //creating output variable to pass
                                                  //to home component through output decorator                              
  model:any={};

  constructor(private accountService:AccountService,private toastr:ToastrService) { }

  ngOnInit(): void {

  }   
  register(){
    this.accountService.register(this.model).subscribe(response=>{
      console.log(response);
      this.cancel();
    },error=>{
      console.log(error);
      this.toastr.error(error.error);
      
    });
  }
  cancel(){
   this.cancelRegister.emit(false);//using built in emit function of class EventEmitter
                                  //and passing our value inside
  }
}
