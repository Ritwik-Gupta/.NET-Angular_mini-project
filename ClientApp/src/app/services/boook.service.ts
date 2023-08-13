import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../interfaces/Book';

@Injectable({
  providedIn: 'root'
})
export class BoookService {

  _baseURL = "https://localhost:7015/api/Books";

  constructor(private http: HttpClient) { }

  public getAllBooks() {
    return this.http.get<Book[]>(this._baseURL);
  }
}
