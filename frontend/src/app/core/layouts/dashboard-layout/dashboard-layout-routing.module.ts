import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BuildingsPage } from 'src/app/features/buildings/pages/buildings/buildings.page';
import { DashboardLayoutComponent } from './dashboard-layout.component';
import { AttackPage } from 'src/app/features/attack/pages/attack/attack.page';

const routes: Routes = [
  {
    path: '',
    component: DashboardLayoutComponent,
     children: [
       { path: 'buildings', component: BuildingsPage },
       { path: 'attack', component: AttackPage }
     ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardLayoutRoutingModule { }
