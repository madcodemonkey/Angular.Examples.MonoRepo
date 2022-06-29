// Docs on Store: https://opensource.salesforce.com/akita/docs/entities/entity-store
import { Injectable } from "@angular/core";
import { EntityState, EntityStore, StoreConfig } from "@datorama/akita";
import { Todo } from "../../_models/todo.model";

// TodosState is used by both the store and the query
export interface TodosState extends EntityState<Todo, string> {
  isLoaded: boolean;
}

@Injectable({
  providedIn: 'root'
})
@StoreConfig({ name: 'todo' })
export class TodoStore extends EntityStore<TodosState> {
  constructor() {
    super({ isLoaded: false });
  }

  loadTodos(courses: Todo[], isLoaded: boolean) {
    this.set(courses);
    this.update(state => ({
      ...state,
      isLoaded
    }));
  }
}

