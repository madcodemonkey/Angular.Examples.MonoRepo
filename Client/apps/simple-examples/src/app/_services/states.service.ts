import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LookupItem } from '../_models/lookupItem.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatesService {
  baseUrl = '/api';

  constructor(private http: HttpClient) { }


  getAll() : Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.baseUrl}/State`);
  }

  getById(id : number) : Observable<LookupItem> {
    return this.http.get<LookupItem>(`${this.baseUrl}/State?id=${id}`);
  }

}
