import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments';
import { formatDate } from '@angular/common';
import { categoryModel } from '../models/category.model';
import { categoryEntryModel } from '../models/category-entry.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseApiUrl: string = environment.apiBaseUrl;

  constructor(private http: HttpClient) {} //to be able to talk http api we need to inject httpclient

  GetAllCategory(): Observable<any[]> {
    return this.http.get<any[]>(this.baseApiUrl + '/Categories/GetCategories');
  }

  AddCategory(category: any): Observable<any> {
    const url = this.baseApiUrl + '/Categories/AddCategory';

    return this.http.post(url, category);
  }

  DeleteCategory(idNumber: number): Observable<any> {
    const url = this.baseApiUrl + '/Categories/DeleteCategory?id=';

    return this.http.delete(url + idNumber);
  }

  updateCategory(category: categoryModel): Observable<any> {
    const categoryData = {
      id: category.id,
      name: category.name,
    };
    // Make an HTTP PUT request to update the category
    return this.http.put(
      this.baseApiUrl + 'Categories/UpdateCategory',
      categoryData
    );
  }
}
