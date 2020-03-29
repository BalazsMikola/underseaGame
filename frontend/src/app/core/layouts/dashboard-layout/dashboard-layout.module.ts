import { NgModule } from '@angular/core';
import { DashboardLayoutRoutingModule } from './dashboard-layout-routing.module';
import { DashboardLayoutComponent } from './dashboard-layout.component';
import { BuildingsModule } from 'src/app/features/buildings/buildings.module';
import { AttackModule } from 'src/app/features/attack/attack.module';

@NgModule({
  declarations: [
    DashboardLayoutComponent
  ],
  imports: [
    DashboardLayoutRoutingModule,
    BuildingsModule,
    AttackModule
  ]
})
export class DashboardLayoutModule { }
