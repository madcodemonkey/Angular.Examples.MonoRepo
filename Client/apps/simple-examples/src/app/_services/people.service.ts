import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../_models/person.model';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  baseUrl = '/api';

  constructor(private http: HttpClient) { }

  getAll() : Observable<Person[]> {
    return this.http.get<Person[]>(`${this.baseUrl}/People`);
  }

  getById(id : number) : Observable<Person> {
    return this.http.get<Person>(`${this.baseUrl}/People/${id}`);
  }
}
