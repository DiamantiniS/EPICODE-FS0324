import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const accessData = this.authService.getAccessData();
    if (!accessData) return next.handle(request);

    const newRequest = request.clone({
      headers: request.headers.append(
        'Authorization',
        `Bearer ${accessData.accessToken}`
      ),
    });
    return next.handle(newRequest);
  }
}
