import { Injectable } from '@angular/core';
import { Category, Menu } from '../Models/Menu';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private apiUrl= "http://localhost:5108/api/";

  constructor(private http: HttpClient) { }

  getAll(): Observable<Menu[]>{
    return this.http.get<Menu[]>(this.apiUrl+ "Menu");
  }

}
