import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
// import {FlexLayoutModule} from '@angular/flex-layout';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { RegisterComponent } from './features/register/register.component';
import { MainComponent } from './features/main/main.component';
import { AuthGuard } from './core/guards/auth.guard';
import { LoginComponent } from './features/login/login.component';
import { TokenInterceptorService } from './core/helpers/interceptors/token-interceptor.service';
import { HeaderComponent } from './features/header/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    MainComponent,
    LoginComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    HttpClientModule,
    // FlexLayoutModule
  ],
  providers: [AuthGuard, CookieService, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
