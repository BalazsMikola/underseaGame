import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttackPage } from './pages/attack/attack.page';

const routes: Routes = [
  { path: '', component: AttackPage },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AttackRoutingModule { }
