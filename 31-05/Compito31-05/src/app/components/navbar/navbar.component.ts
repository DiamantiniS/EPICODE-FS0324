import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  searchText: string = '';

  @Output() searchEvent = new EventEmitter<string>();

  onSearch() {
    this.searchEvent.emit(this.searchText);
  }
}
