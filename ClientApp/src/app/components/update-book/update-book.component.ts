import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private service: BoookService, private activatedRoute: ActivatedRoute) {
    debugger;
    this.activatedRoute.queryParams.subscribe(data => {
      this.bookId = data.id;
    });
  }

  ngOnInit(): void {
    this.service.getBookById(this.bookId).subscribe(data => {
      debugger;
      this.book = data;
    })
  }

  saveBook(): void {
    debugger;
  }

}
