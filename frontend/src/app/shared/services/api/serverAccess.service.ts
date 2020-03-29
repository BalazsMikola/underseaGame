import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IRegister } from 'src/app/shared/models/IRegister';
import { ILogin } from 'src/app/shared/models/ILogin';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ServerAccessService {


  private serverUrl: string = environment.serverUrl;


  constructor(private http: HttpClient) { }


  public registerNewUser(username: string, password: string, city: string): Observable<object> {
    const requiestBody: IRegister = {
      User: username,
      City: city,
      Password: password
    };
    return this.http.post(`${this.serverUrl}register`, requiestBody);
  }


  public loginUser(username: string, password: string): Observable<object> {
    const requiestBody: ILogin = {
      User: username,
      Password: password
    };
    return this.http.post(`${this.serverUrl}login`, requiestBody);
  }


  public getCityData(): Observable<object> {
    return this.http.get(`${this.serverUrl}city`);
  }


}
