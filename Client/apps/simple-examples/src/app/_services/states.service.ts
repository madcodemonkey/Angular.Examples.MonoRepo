import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { State } from '../_models/state.model';

@Injectable({
  providedIn: 'root'
})
export class StatesService {
  baseUrl = '/api';

  constructor(private http: HttpClient) { }


  getAll() : Observable<State[]> {
    return this.http.get<State[]>(`${this.baseUrl}/State`);
  }

  getById(id : number) : Observable<State> {
    return this.http.get<State>(`${this.baseUrl}/State?id=${id}`);
  }

  getByCountryId(countryId : number) : Observable<State[]> {
    return this.http.get<State[]>(`${this.baseUrl}/State/country/${countryId}`);
  }
}
