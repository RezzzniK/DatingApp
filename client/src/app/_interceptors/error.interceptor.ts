import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router:Router/*we adding this for certain kind of errors that we want to redirect*/,
    private toastr:ToastrService/*for some kind of errors we might want to show toastr notifications*/) {}
  //here we catching the requests thats comes out or responses that commes in in next
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error /*http response that we saw on console log when we clicked on the button*/=>{
        //checking if there is an error
        if(error){
            switch (error.status) {
              case 400:
                      if(error.error.errors){
                        const modalStateErrors=[];
                        for(const key in error.error.errors){
                          if(error.error.errors[key]){
                             modalStateErrors.push(error.error.errors[key])
                           }
                        }
                        throw modalStateErrors.flat();
                      }
                      else{
                        this.toastr.error(error.statusText,error.status);
                      }
                
                break;
              case 401:
                      this.toastr.error(error.statusText,error.status);
                 break;
              case 404:
                      this.router.navigateByUrl('/not-found');
                 break;
              case 500:
                      const navigationExtras:NavigationExtras={
                      //we adding this because with redirect we also want to pas status
                      state:{error:error.error}//exception the we getting from api
                      }
                      this.router.navigateByUrl('/server-error',navigationExtras);
                      /*error handling of this case is have navigation extras
                      we want to handle this inside our app */
                 break;      
                                                            
              default:
                this.toastr.error('Somthing unexpected went wrong');
                console.log(error);
                break;
            }
        }
        return throwError(error);
      })
      )
    
  }
}
