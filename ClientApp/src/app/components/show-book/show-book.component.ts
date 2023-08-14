import { Component, OnInit } from '@angular/core';
import { Book } from '../../interfaces/Book';
import { ActivatedRoute } from '@angular/router';
import { BoookService } from 'src/app/services/boook.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit {

  public book: Book;
  private bookId : number;

  constructor(private activatedRoute: ActivatedRoute, private service: BoookService) {
    this.activatedRoute.queryParams.subscribe(data => {
      this.bookId = data.id;
    })
  }

  ngOnInit(): void {
    this.service.getBookById(this.bookId).subscribe(data => {
      debugger;
      this.book = data;
    })
  }

}
