import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BoookService } from 'src/app/services/boook.service';
import { Book } from 'src/app/interfaces/Book';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  public book: Book;
  private bookId: number;

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

  saveBook(): any {
    this.service.updateBook(this.book, this.bookId);
    this.router.navigate(['/books']);
  }

}
