import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Todo, TodoStatus } from '../../_models/todo.model';
import { TodoStore } from './todo.store';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseUrl = "/api";

  constructor(private httpClient: HttpClient,
    private store: TodoStore) { }

  addTask(title: string, description: string): Observable<Todo> {
    return this.httpClient.post<Todo>(`${this.baseUrl}/todo`, { title: title, description: description, status: TodoStatus.Open }).pipe(
      tap(value => {
        this.store.add([value]);
      })
    );
  }

  getTodos(): Observable<Todo[]> {
    this.store.setLoading(true);
    return this.httpClient.get<Todo[]>(`${this.baseUrl}/todo`).pipe(
      tap(todos => {
        this.store.loadTodos(todos, true);
        this.store.setLoading(false);
      }));
  }

  deleteTodo(id: string): Observable<Todo> {
    return this.httpClient.delete<Todo>(`${this.baseUrl}/todo/${id}`).pipe(
      tap(result => {
        this.store.remove(id);
      })
    );
  }

  /**
   * Marks one item as done by calling the updateTodo function.
   * @param item The item that should be marked as done.
   * @returns Observable<Todo>
   */
  updateTodoStatus(item: Todo, newStatus: TodoStatus): Observable<Todo> {
    // Spread the item and up date one field (status)
    let changedItem: Todo = { ...item, status: newStatus };

    return this.updateTodo(item.id, changedItem);
  }

  updateTodo(id: string, changedTodo: Todo): Observable<Todo> {
    this.store.setLoading(true);
    return this.httpClient.put<Todo>(`${this.baseUrl}/todo/${id}`, changedTodo).pipe(
      tap(result => {
        this.store.update(id, changedTodo);
        this.store.setLoading(false);
      })
    );
  }

  setIsLoading(isLoading: boolean) {
    this.store.setLoading(isLoading);
  }
}
