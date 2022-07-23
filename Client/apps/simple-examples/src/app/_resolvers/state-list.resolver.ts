import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { State } from '../_models/state.model';
import { StatesService } from '../_services/states.service';

@Injectable({
  providedIn: 'root'
})
export class StateListResolver implements Resolve<State[]> {

  constructor(private stateSerivce : StatesService) {
  }

  resolve(route: ActivatedRouteSnapshot): Observable<State[]> {
    return this.stateSerivce.getAll();
  }
}
