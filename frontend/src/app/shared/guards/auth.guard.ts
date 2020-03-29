import { Injectable } from '@angular/core';
import { Router, CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from '../services/api/authentication.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(
    private authenticationService: AuthenticationService
  ) { }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(childRoute, state);
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    const jwtoken: string = localStorage.getItem('accessToken');
    const username: string = localStorage.getItem('currentUser');

    if (jwtoken && username) {

      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken(jwtoken);
      const isExpired = helper.isTokenExpired(jwtoken);

      if (decodedToken.sub === username && !isExpired) {
        return true;
      } else {
        this.authenticationService.logout();
        return false;
      }

    } else {
      this.authenticationService.logout();
      return false;
    }
  }
}
