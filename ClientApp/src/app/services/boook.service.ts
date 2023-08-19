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

  public getBookById(id: number) {
    const _url = this._baseURL + `/GetBookById?id=${id}`;
    debugger;
    return this.http.get<Book>(_url);
  }

  public getNextAvailableBookId() {
    const _url = this._baseURL + `/GetNextAvailableId`;
    return this.http.get<number>(_url);
  }

  public addNewBook(book: Book) {
    const _url = this._baseURL + `/AddBook`;
    this.http.post<any>(_url, book).subscribe();
  }

  public updateBook(book: Book, id: number) {
    const _url = this._baseURL + `/UpdateBook`;
    this.http.post<any>(_url + `?id=${id}`, book).subscribe();
  }

  public deleteBook(id: number) {
    const _url = this._baseURL + `/DeleteBook`;
    this.http.get<any>(_url + `?id=${id}`).subscribe();
  }
}
