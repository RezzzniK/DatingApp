import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService:AccountService,private toastr:ToastrService){}
  canActivate(): Observable<boolean> {//we returning observable as a boolean
    return this.accountService.currentUser$.pipe(//getting observable user
      map(user=>{
        if(user) return true;//if the currentUser$ not empty
                           //we will return true
        this.toastr.error('You shall not pass!');
      })
    );
  }
  
}
