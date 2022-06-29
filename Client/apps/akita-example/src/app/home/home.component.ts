import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { filter, Subject, switchMap, take, takeUntil } from 'rxjs';
import { TodoQuery } from '../state/todo/todo.query';
import { Todo, TodoStatus } from '../_models/todo.model';
import { TodoService } from '../state/todo/todo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  loading = false;
  todos: Todo[] = [];
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private router: Router,
    private todoQuery: TodoQuery,
    private todoService: TodoService) { }

  ngOnInit(): void {
    // Subscribe to isLoading so that the spinner works when things are being loaded or updated.
    this.todoQuery.getIsLoading()
      .pipe(takeUntil(this.destroy$))
      .subscribe(res => this.loading = res);

    // Subscribe to changes in the todo array and update things locally.
    this.todoQuery.getTodos()
      .pipe(takeUntil(this.destroy$))
      .subscribe(res => this.todos = res);

    // Check if things are loaded only once (take(1)) and usin gthe service to load things if needed.
    this.todoQuery.getIsLoaded().pipe(
      take(1),
      filter(res => !res),  // only execute the swithmap if the result is false (things are not loaded)
      switchMap(() => {
        this.todoService.setIsLoading(true);
        return this.todoService.getTodos();
      })
    ).subscribe(
      {
        next: (res) => { },
        error: (err) => {
          console.log(err);
          this.todoService.setIsLoading(false);
        }
      });
  }

  addToDo() {
    this.router.navigateByUrl('/add-todo');
  }

  markAsComplete(item: Todo) {
    this.todoService.updateTodoStatus(item, TodoStatus.Done).subscribe(
      {
        next: (updatedTodo: Todo) => { console.log(updatedTodo); },
        error: err => console.log(err)
      });
  }

  deleteTodo(item: Todo) {
    this.todoService.deleteTodo(item.id).subscribe(
      {
        next: res => { },
        error: err => console.log(err)
      });
  }


  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
