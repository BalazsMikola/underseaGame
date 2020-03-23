import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor() { }


  intercept(req, next): Observable<HttpEvent<any>> {
    const requiestWithToken = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + localStorage.getItem('accessToken')
      }
    });
    return next.handle(requiestWithToken);
  }
}
