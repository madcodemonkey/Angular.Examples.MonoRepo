import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { LookupItem } from '../_models/lookupItem.model';
import { StatesService } from '../_services/states.service';

@Injectable({
  providedIn: 'root'
})
export class StateListResolver implements Resolve<LookupItem[]> {

  constructor(private stateSerivce : StatesService) {
  }

  resolve(route: ActivatedRouteSnapshot): Observable<LookupItem[]> {
    return this.stateSerivce.getAll();
  }
}
