import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeLayoutComponent } from './welcome-layout.component';
import { LoginComponent } from '../../components/login/login.component';
import { RegisterComponent } from '../../components/register/register.component';

const routes: Routes = [
  {
    path: '',
    component: WelcomeLayoutComponent,
     children: [
       { path: '', component: LoginComponent },
       { path: 'register', component: RegisterComponent }
     ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WelcomeLayoutRoutingModule { }
