import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ServerAccessService } from './serverAccess.service';
import { IToken } from '../../models/IToken';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private serverAccessService: ServerAccessService,
    private router: Router
  ) { }


  public get getCurrentUsername(): string {
    return localStorage.getItem('currentUsername');
  }


  public register(username: string, password: string, city: string): void {
    this.serverAccessService.registerNewUser(username, password, city)
      .subscribe(response => {
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
      .subscribe((response: IToken) => {
        if (response !== null) {
          localStorage.setItem('accessToken', response.Token);
          localStorage.setItem('currentUser', username);
          this.serverAccessService.getCityData().subscribe(cityData => {
            if (cityData) {
              console.log(cityData);
              this.router.navigate(['/dashboard']);
            }
          }, error => {
            if (error.status === 401) {
              this.logout();
            }
          });
        }
      }, error => {
        alert(error.error);

      });
  }


  logout(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('accessToken');
    this.router.navigate(['/']);
  }

}
