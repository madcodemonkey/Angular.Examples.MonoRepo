import { Component, OnInit } from '@angular/core';
import { ThemeService } from '../../_services/theme.service';

@Component({
  selector: 'yates-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private themeService: ThemeService) {}

  ngOnInit(): void {
  }

  toggle() {
    this.themeService.toggle();
  }
}
