import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/interfaces/Book';
import { BoookService } from 'src/app/services/boook.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {

  id: number;
  title: string;
  author: string;
  description: string;
  dateStart: Date;
  dateRead: Date;
  rating: string;

  newBook: Book = {
    id: 0,
    title: "",
    author: "",
    description: "",
    dateStart: undefined,
    dateRead: undefined,
    rate: undefined,
  }

  constructor(private service: BoookService, private router: Router) { }

  ngOnInit(): void {
    this.service.getNextAvailableBookId().subscribe(data => {
      this.id = data;
    });
  }

  saveBook() {
    this.newBook.id = this.id;
    this.newBook.title = this.title;
    this.newBook.author = this.author;
    this.newBook.description = this.description;
    this.newBook.dateStart = this.dateStart;
    this.newBook.dateRead = this.dateRead;
    this.newBook.rate = this.rating;

    this.service.addNewBook(this.newBook);
    this.router.navigate(['/books']);
  }

  test() {
    console.log(this.title);
  }

}
