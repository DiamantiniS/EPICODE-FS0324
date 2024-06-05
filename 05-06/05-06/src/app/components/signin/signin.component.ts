import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent {
  email!: string
  password!: string
  constructor(private authSrv: AuthService) { }

  submitLogin(form: NgForm) {
    this.authSrv.login(form.value.credentials).subscribe(res => console.log(res))
  }
}
