import { NgModule } from '@angular/core';
import { DashboardLayoutModule } from './layouts/dashboard-layout/dashboard-layout.module';
import { WelcomeLayoutModule } from './layouts/welcome-layout/welcome-layout.module';

@NgModule({

  declarations: [],
  imports : [
    WelcomeLayoutModule,
    DashboardLayoutModule
  ]
})
export class CoreModule {

}
