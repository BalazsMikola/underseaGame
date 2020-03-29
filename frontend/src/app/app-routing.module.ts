import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  { path: '', loadChildren: './core/layouts/welcome-layout/welcome-layout.module#WelcomeLayoutModule'},
  { path: 'dashboard', canActivateChild: [AuthGuard],
    loadChildren: './core/layouts/dashboard-layout/dashboard-layout.module#DashboardLayoutModule'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
