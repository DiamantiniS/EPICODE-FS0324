import { Component, OnInit } from '@angular/core';
import { SignUp } from '../../interfaces/auth.interface';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent {
  users!: SignUp[]
  constructor(private userSrv: AuthService) {
    this.userSrv.userList.subscribe(_users => {
      this.users = _users
    })
  }

}
