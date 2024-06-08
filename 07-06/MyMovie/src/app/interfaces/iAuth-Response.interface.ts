import { iUsers } from './iUsers.interface';

export interface iAuthResponse {
  accessToken: string;
  user: iUsers;
}
