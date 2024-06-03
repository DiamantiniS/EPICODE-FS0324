import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  loggedin: boolean = false;
  constructor() {}
  isAuthenticated() {
    return new Promise((res, rej) => {
      setTimeout(() => {
        res(this.loggedin);
      }, 1000);
    });
  }
  login() {
    this.loggedin = true;
  }
  logout() {
    this.loggedin = false;
  }
}
