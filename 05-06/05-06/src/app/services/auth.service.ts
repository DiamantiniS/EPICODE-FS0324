import { Injectable } from '@angular/core';
import { Auth, LoginData, SignUp } from '../interfaces/auth.interface';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLogged$ = new BehaviorSubject<boolean>(false)
  loggedStatus = this.isLogged$.asObservable()

  jwtSrv = new JwtHelperService()

  constructor(private http: HttpClient, private router: Router) { }

  login(cred: Auth) {
    return this.http.post<LoginData>(`${environment.srvr}login`, cred).pipe(tap((res) => {
      console.log(res)
      if (res.accessToken) {
        localStorage.setItem("user", JSON.stringify(res))
        this.isLogged$.next(res.accessToken ? true : false)
        this.router.navigateByUrl("")
      } else alert("no login for you")
    }))
  }


  signup(formData: SignUp) {
    return this.http.post(`${environment.srvr}signup`, formData).pipe(tap((res) => {
      console.log(res)
    }))
  }

  logout() {
    localStorage.removeItem("user")
    this.isLogged$.next(false)
    this.router.navigateByUrl("login")
  }

  currentLoggedUsed():Observable<SignUp[]> | undefined {
    const dati = this.getLoginData
    if(dati) {
      const email = dati.user.email
      return this.http.get<SignUp[]>(`${environment.srvr}users?email=${email}`)
    } else {
      this.isLogged$.next(false)
      return
    }
  }

  private get getLoginData() {
    const ls = JSON.parse(localStorage.getItem("user")!) as LoginData | null
    if (ls) return ls
    else return false
  }

  verifyLogin() {
    const data = this.getLoginData
    if (data) {
      const isExpired = this.jwtSrv.isTokenExpired(data.accessToken)
      this.isLogged$.next(!isExpired)
    } else {
      this.isLogged$.next(false)
    }
  }

}
