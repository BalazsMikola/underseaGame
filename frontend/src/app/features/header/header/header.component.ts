import { Component, OnInit, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RouteConfigLoadEnd } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  cityData = new BehaviorSubject<object>(null);

  round = 0;
  rank = 0;
  lezercapa = 0;
  rohamfoka = 0;
  csatacsiko = 0;
  pearl = 0;
  coral = 0;
  aramlasiranyito = 0;
  zatonyvar = 0;

  @Input() set data(value) {
    this.cityData.next(value);
  }

  constructor() { }

  ngOnInit() {

  }

  // tslint:disable-next-line: use-lifecycle-interface
  ngOnDestroy() {
    this.cityData.unsubscribe();
  }

}
