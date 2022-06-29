export interface Todo {
  id: string;
  title: string;
  description: string;
  status: TodoStatus;
}


export enum TodoStatus {
  Open = 'open',
  Done = 'done'
}
