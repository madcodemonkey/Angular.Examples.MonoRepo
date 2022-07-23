import { Component, OnInit } from '@angular/core';
import { Country } from '../../../_models/country.model';
import { State } from '../../../_models/state.model';
import { CountryService } from '../../../_services/country.service';
import { StatesService } from '../../../_services/states.service';

@Component({
  selector: 'yates-cascade-dropdown-list',
  templateUrl: './cascade-dropdown-list.component.html',
  styleUrls: ['./cascade-dropdown-list.component.scss'],
})
export class CascadeDropdownListComponent implements OnInit {
  countryList: Country[] = [];
  selectedCountryValue = 0;
  stateList: State[] = [];
  selectedStateValue = 0;

  constructor(
    private countryService: CountryService,
    private stateService: StatesService
  ) {}

  ngOnInit(): void {
    this.countryService.getAll().subscribe((response) => {
      this.countryList = response;
    });
  }

  onChangeCountry(data: any) {
    this.stateService
      .getByCountryId(this.selectedCountryValue)
      .subscribe((response) => {
        this.stateList = response;
      });
  }
}
