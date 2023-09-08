import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { CategoriesComponent } from './Components/categories/categories.component';

const routes: Routes = [
  {
    path: 'category',
    component: CategoriesComponent, // Use the function to determine the component
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}