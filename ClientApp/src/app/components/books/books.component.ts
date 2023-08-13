import { Component, OnInit } from '@angular/core';
import { BoookService } from '../../services/boook.service';
import { Book } from '../../interfaces/Book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  public books: Book[];

  constructor(private service: BoookService) { }

  ngOnInit(): void {
    console.log("working");
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

}
