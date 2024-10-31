import { Routes } from '@angular/router';
import { MenuComponent } from './menu/menu.component';


export const routes: Routes = [
  {path: '', component: MenuComponent},
  {path: 'menu/:category', component: MenuComponent},
];
