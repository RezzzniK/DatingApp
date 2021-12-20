import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from '_services/account.service';
import { User } from '../_models/user';
import { take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(/*in matter to bring our token from local
     storage we injecting accountService service*/
     private accountService:AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
   //bringing our current user observable
   let currentUser:User;
   this.accountService.currentUser$.pipe(take(1)).subscribe(user=>currentUser=user);//we will get the value from user if its not null
   if(currentUser){
     request=request.clone({
       setHeaders:{
         Authorization: `Bearer ${currentUser.token}`
       }
     })
   }
    return next.handle(request);
  }
}
