import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../services/auth.service';
import { SignUp } from '../../interfaces/auth.interface';


@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
  user:SignUp = {} as SignUp
  constructor(private authSrv: AuthService) { }

  ngOnInit(): void {
    this.authSrv.currentLoggedUsed()?.subscribe(user => this.user = user[0])
  }

  logout() {
    this.authSrv.logout()
  }

}
