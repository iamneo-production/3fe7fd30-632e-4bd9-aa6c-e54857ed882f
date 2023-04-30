import { Component } from '@angular/core';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Life Insurance';
  search!: string;
 
  onSearchClicked(search: string) {
    this.search = search;
  }
}
