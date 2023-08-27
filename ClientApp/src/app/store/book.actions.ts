import { Action } from "@ngrx/store";
import { Book } from "../interfaces/Book";
import * as types from "../store/action.types";

export class loadBooksAction implements Action {

  readonly type = types.LOAD_BOOKS;
  constructor() { }
}

export class loadBooksSuccessAction implements Action {

  readonly type = types.LOAD_BOOKS_SUCCESS;
  constructor(public payload: Book[]) {

  }
}
