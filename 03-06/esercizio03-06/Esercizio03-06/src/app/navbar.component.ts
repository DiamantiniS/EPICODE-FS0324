import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-navbar',
  template: `
    <nav class="navbar navbar-expand navbar-light bg-light">
      <div class="container-fluid">
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarTogglerDemo01"
          aria-controls="navbarTogglerDemo01"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
          <a class="navbar-brand" href="#">Hidden brand</a>
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <a
                class="nav-link active"
                aria-current="page"
                [routerLink]="['/']"
                routerLinkActive="active"
                [routerLinkActiveOptions]="{ exact: true }"
                >Home</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                [routerLink]="['/active-posts']"
                routerLinkActive="active"
                >Posts attivi</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                [routerLink]="['/inactive-posts']"
                routerLinkActive="active"
                >Posts non attivi</a
              >
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                [routerLink]="['/users']"
                routerLinkActive="active"
                >Users</a
              >
            </li>
            <!-- <li class="nav-item">
              <a
                class="nav-link"
                [routerLink]="['/users/new']"
                routerLinkActive="active"
                >Nuovo Utente</a
              >
            </li> -->
          </ul>
          <button (click)="login()">login</button>
          <button (click)="logout()">logout</button>
        </div>
      </div>
    </nav>
  `,
  styles: [],
})
export class NavbarComponent implements OnInit {
  constructor(private authSrv: AuthService) {}
  async login() {
    if (await this.authSrv.isAuthenticated()) {
      alert('Utente già loggato');
    } else {
      this.authSrv.login();
      alert('Utente loggato');
    }
  }
  async logout() {
    if (await this.authSrv.isAuthenticated()) {
      this.authSrv.logout();
      alert('Utente uscito');
    } else {
      alert('Utente non loggato');
    }
  }
  ngOnInit(): void {}
}
