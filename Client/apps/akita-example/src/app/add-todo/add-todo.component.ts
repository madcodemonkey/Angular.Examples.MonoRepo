import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, take } from 'rxjs';
import { TodoService } from '../state/todo/todo.service';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrls: ['./add-todo.component.scss']
})
export class AddTodoComponent implements OnInit {
  form!: FormGroup;

  constructor(private todoService: TodoService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      title: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required])
    });
  }

  addTodo() {
    this.todoService.setIsLoading(true);
    this.todoService.addTask(this.form.controls['title'].value, this.form.controls['description'].value)
      .pipe(take(1))
      .subscribe(res => {
        this.todoService.setIsLoading(false);
        this.router.navigateByUrl('');
      });
  }
}
