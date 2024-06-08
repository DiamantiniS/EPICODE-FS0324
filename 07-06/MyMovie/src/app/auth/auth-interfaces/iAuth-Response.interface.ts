import { iUsers } from '../../interfaces/iUsers.interface';

export interface iAuthResponse {
  accessToken: string;
  user: iUsers;
}
