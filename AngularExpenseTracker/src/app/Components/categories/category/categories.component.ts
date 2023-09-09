import { Component, OnInit } from '@angular/core';
import { categoryModel } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { categoryEntryModel } from '../models/category-entry.model';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  public categories!: categoryModel[];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.populateCategoryList();
  }

  populateCategoryList() {
    this.categoryService.GetAllCategory().subscribe({
      next: (data) => {
        this.categories = data;
      },
      error: (err: any) => console.log('error: ' + err),
    });
  }
  deleteCategoryEvent(id: number) {
    console.log('deleteCategoryEvent called');
    this.categoryService.DeleteCategory(id).subscribe(
      (response) => {
        // Handle success, e.g., show a success message
        alert('Data deleted successfully !! ');
        console.log('Item deleted successfully', response);
        // Populate the category list again after a successful delete
        this.populateCategoryList();
      },
      (error) => {
        // Handle error, e.g., show an error message
        console.error(error);
      }
    );
  }
  updateCategoryEvent(category: categoryModel) {
    console.log('updateCategoryEvent called');
    this.categoryService.updateCategory(category);
  }
  addCategoryEvent(categoryName: string) {
    this.categoryService.AddCategory({ CategoryName: categoryName }).subscribe({
      next: (response) => {
        console.log(response);
        this.populateCategoryList();
      },
      error: (err) => {
        console.log(err.error);
      },
    });
  }
}
