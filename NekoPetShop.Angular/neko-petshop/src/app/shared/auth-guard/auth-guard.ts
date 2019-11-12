import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private authenticationService: AuthenticationService) { }

    canActivate() {
        if (this.authenticationService.getToken()) {
          if (this.authenticationService.isAdmin()) {
            return true;
          }
          else{
            this.router.navigate(['/']);
            return false;   
          }
        }

        this.router.navigate(['/login']);
        return false;
    }
}