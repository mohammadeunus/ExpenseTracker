import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExpenseComponent } from './Components/expense/expense.component';
import { CategoriesComponent } from './Components/categories/category/categories.component';
import { CategoryEditComponent } from './Components/categories/category-edit/category-edit.component';

const routes: Routes = [
  {
    path: 'category',
    component: CategoriesComponent, // Use the function to determine the component
  },
  {
    path: 'category-edit',
    component: CategoryEditComponent, // Use the function to determine the component
  },
  {
    path: 'expenses',
    component: ExpenseComponent, // Use the function to determine the component
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
