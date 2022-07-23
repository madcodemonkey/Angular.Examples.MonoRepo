import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../_models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  baseUrl = '/api';

  constructor(private http: HttpClient) { }


  getAll() : Observable<Country[]> {
    return this.http.get<Country[]>(`${this.baseUrl}/Country`);
  }

  getById(id : number) : Observable<Country> {
    return this.http.get<Country>(`${this.baseUrl}/Country?id=${id}`);
  }

}
