import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { CategoriesComponent } from './Components/categories/categories.component';
import { AppRoutingModule } from './app-routing.module';
import { ExpenseComponent } from './components/expense/expense.component';

@NgModule({
  declarations: [AppComponent, NavBarComponent, CategoriesComponent, ExpenseComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
