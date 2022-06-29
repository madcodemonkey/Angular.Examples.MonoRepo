// Docs on Query: https://opensource.salesforce.com/akita/docs/entities/query-entity
import { Injectable } from "@angular/core";
import { QueryEntity } from "@datorama/akita";
import { Observable } from "rxjs";
import { Todo } from "../../_models/todo.model";
import { TodosState, TodoStore } from "./todo.store";


@Injectable({
  providedIn: 'root'
})
export class TodoQuery extends QueryEntity<TodosState> {
  constructor(protected todoStore: TodoStore) {
    super(todoStore);
  }

  // https://opensource.salesforce.com/akita/docs/entities/query-entity#selectall
  getTodos(): Observable<Todo[]> {
    return this.selectAll();
  }

  getIsLoaded(): Observable<boolean> {
    return this.select(state => state.isLoaded);
  }

  // https://opensource.salesforce.com/akita/docs/entities/query-entity#selectloading
  getIsLoading(): Observable<boolean> {
    return this.selectLoading();
  }

}
