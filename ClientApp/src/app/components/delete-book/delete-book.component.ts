import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BoookService } from 'src/app/services/boook.service';
import { Book } from 'src/app/interfaces/Book';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrls: ['./delete-book.component.css']
})
export class DeleteBookComponent implements OnInit {

  bookId: number;
  book: Book;

  constructor(private service: BoookService, private activatedRoute: ActivatedRoute, private router: Router) {
    this.activatedRoute.queryParams.subscribe(data => {
      this.bookId = data.id;
    });
  }

  ngOnInit(): void {
    this.service.getBookById(this.bookId).subscribe(data => {
      this.book = data;
    })
  }

  deleteBook(): void {
    debugger;
    this.service.deleteBook(this.bookId);
    this.router.navigate(['/books']);
  }

}
