import { NgModule } from '@angular/core';
import { WelcomeLayoutRoutingModule } from './welcome-layout-routing.module';
import { WelcomeLayoutComponent } from './welcome-layout.component';
import { LoginComponent } from '../../components/login/login.component';
import { RegisterComponent } from '../../components/register/register.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    WelcomeLayoutComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    SharedModule,
    WelcomeLayoutRoutingModule,
  ]
})
export class WelcomeLayoutModule { }
