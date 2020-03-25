import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from '../../core/authentication/authentication.service';
import { ServerAccessService } from '../../core/http/serverAccess.service';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { ICity } from 'src/app/shared/models/ICity';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  cityData = {};

  constructor(
    private authenticationService: AuthenticationService,
    private serverAccessService: ServerAccessService,
    private router: Router
  ) { }

  ngOnInit() {
    this.serverAccessService.getCityData().pipe(take(1)).subscribe(cityData => {
      if (cityData) {
        this.cityData = cityData;
      }
    }, error => {
      if (error.status === 401) {
        this.onLogout();
      }
    });
  }

  onLogout(): void {
    this.authenticationService.logout();
  }


}
