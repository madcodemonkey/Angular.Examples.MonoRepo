import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { Todo } from './_models/todo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;
  title = 'grid-demo';

  rowData: Todo[] | null = null;

//  rowData$: Observable<Todo[]> | null = null;
  search = new FormControl('');

  // rowData: any[] = [
  //   { id:'123', title: 'Get milk', description: 'dd', status:'open'  },
  //   { id:'124', title: 'Get dog food', description: 'ffe', status:'open'  },
  //   { id:'125', title: 'Get cheese', description: 'fff', status:'open'  }
  // ];

  colDefs: ColDef[] = [
    { field: 'id', sortable: true, filter: false },
    { field: 'title' },
    { field: 'description' },
    { field: 'status' }
  ];

  defaultColDef: ColDef = { sortable: true, filter: true };

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.search.valueChanges.subscribe((val) => {
        this.agGrid.api.setQuickFilter(val ?? '');
    });

   //    this.rowData$ = this.http.get<Todo[]>("https://localhost:7114/api/todo");
   this.http.get<Todo[]>("api/todo").subscribe(res => {
      this.rowData = res;
   });
  }


}
