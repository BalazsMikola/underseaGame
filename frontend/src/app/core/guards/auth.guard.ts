import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthenticationService } from '../authentication/authentication.service';

@Injectable()
export class AuthGuard {

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) { }

  canActivate(state: RouterStateSnapshot) {

    const currentUser = this.authenticationService.getCurrentUsername;
    if (state.url === '/login') {
      if (currentUser) {
        this.router.navigate(['/']);
        return false;
      } else {
        return true;
      }
    } else if (state.url === '/register') {
      if (currentUser) {
        this.router.navigate(['/']);
        return false;
      } else {
        return true;
      }
    } else if (state.url === '/') {
      if (currentUser) {
        return true;
      } else {
        this.router.navigate(['/login']);
        return false;
      }
    }

  }
}
