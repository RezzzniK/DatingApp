import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})

export class ServerErrorComponent implements OnInit {
  error:any;//class property for errors
/* we need to inject our rout into constructor,so we will got accsess to router state*/
  constructor(private router:Router/*the only place that we can hold and accsess the
     router state is inside our constructor */) {
       const navigation=this.router.getCurrentNavigation();//here we reciveing current 
                                                          //router navigation state
       this.error=navigation?.extras?.state?.error;//we don't know when the error will navigate to this page
                            //so "?" will prevent to our error to get null state
                           // and will recive value only in case if user was redirect 
                          //to this page


      }

  ngOnInit(): void {
  }

}
