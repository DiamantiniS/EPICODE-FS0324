import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { iUsers } from '../interfaces/iUsers.interface';
import { iAuthResponse } from './auth-interfaces/iAuth-Response.interface';
import { iAuthData } from './auth-interfaces/iAuth-Datas.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService();

  authSubject = new BehaviorSubject<null | iUsers>(null);

  syncIsLoggedIn: boolean = false;

  user$ = this.authSubject.asObservable();

  isLoggedIn$ = this.user$.pipe(
    map((user) => !!user),
    tap((user) => (this.syncIsLoggedIn = user))
  );

  loginUrl: string = 'http://localhost:3000/login';
  registerUrl: string = 'http://localhost:3000/register';

  constructor(private http: HttpClient, private router: Router) {
    this.restoreUser();
  }

  register(newUser: Partial<iUsers>): Observable<iAuthResponse> {
    return this.http.post<iAuthResponse>(this.registerUrl, newUser);
  }

  //
  login(authData: iAuthData): Observable<iAuthResponse> {
    return this.http.post<iAuthResponse>(this.loginUrl, authData).pipe(
      tap((data) => {
        this.authSubject.next(data.user);

        localStorage.setItem('accessData', JSON.stringify(data));

        this.autologout();
      })
    );
  }

  //
  logout(): void {
    this.authSubject.next(null);

    localStorage.removeItem('accessData');

    this.router.navigate(['']);
  }

  //
  autologout(): void {
    const accessData = this.getAccessData();

    if (!accessData) return;

    const expDate = this.jwtHelper.getTokenExpirationDate(
      accessData.accessToken
    ) as Date;

    const expMs = expDate.getTime() - new Date().getTime();

    setTimeout(() => {
      this.logout();
    }, expMs);
  }

  //
  getAccessData(): iAuthResponse | null {
    const accessDataJson = localStorage.getItem('accessData');

    if (!accessDataJson) return null;

    const accessData: iAuthResponse = JSON.parse(accessDataJson);

    return accessData;
  }

  //
  restoreUser(): void {
    const accessData = this.getAccessData();

    if (!accessData) return;

    if (this.jwtHelper.isTokenExpired(accessData.accessToken)) return;

    this.authSubject.next(accessData.user);
    this.autologout();
  }
}
