import { Component } from '@angular/core';
import { BoookService } from 'src/app/services/boook.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  bookId: string;

  constructor(private service: BoookService) { }

  getBookInfoById(id: string) {
    debugger;
    this.service.getBookById(parseInt(id));
  }
}
