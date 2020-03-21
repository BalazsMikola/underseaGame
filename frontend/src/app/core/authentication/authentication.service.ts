import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';

import { environment } from '../../../environments/environment';
import { ServerAccessService } from '../http/serverAccess.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  private serverUrl: string = environment.serverUrl;
  private pathRegister: string = environment.pathRegister;


  constructor(
    private http: HttpClient,
    private serverAccessService: ServerAccessService,
    private router: Router,
  ) { }


  public get getCurrentUsername(): string {
    return localStorage.getItem('currentUsername');
  }


  public register(username: string, password: string, city: string): void {
    this.serverAccessService.registerNewUser(username, password, city)
      .pipe(take(1)).subscribe(response => {
        if (response === null) {
          alert('Sikeres regisztráció! Most már beléphetsz!');
          this.router.navigate(['/login']);
        }
      }, error => {
        alert(error.error);
      });
  }


  public login(username: string, password: string): void {
    this.serverAccessService.loginUser(username, password)
      .pipe(take(1)).subscribe(response => {
        if (response) {
          console.log(response);
          localStorage.setItem('currentUsername', username);
          this.router.navigate(['/']);
        }
      }, error => {
        alert(error.error);
      });
  }


  logout(): void {
    localStorage.removeItem('currentUsername');
    this.router.navigate(['/login']);
  }

}
