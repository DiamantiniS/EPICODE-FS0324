import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms"
import { AuthService } from '../../services/auth.service';
import { passwordMatch, passwordValidator } from '../../utils/password.validator';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {
  user: FormGroup = new FormGroup({
    nome: new FormControl("", [Validators.required]),
    cognome: new FormControl("", [Validators.required]),
    password: new FormControl("", [passwordMatch()]),
    passwordConf: new FormControl("", [passwordMatch()]),
    email: new FormControl("", [Validators.required]),
  }, {
    validators: passwordValidator
  })
  constructor(private authSrv: AuthService) { }

  submitForm(form: FormGroup) {
    delete form.value.passwordConf
    this.authSrv.signup(form.value).subscribe(res => console.log(res))
  }

}
