import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AttackComponent } from './components/attack/attack.component';
import { AttackPage } from './pages/attack/attack.page';

@NgModule({
  declarations: [
    AttackPage,
    AttackComponent
  ],
  imports: []
})
export class AttackModule { }
