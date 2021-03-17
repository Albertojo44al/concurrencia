import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { EventoComponent } from './evento/evento.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: CategoriesComponent
      },
      {
        path: 'evento',
        component: EventoComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
