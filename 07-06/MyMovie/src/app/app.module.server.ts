import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppModule } from './app.module';

@NgModule({
  imports: [AppModule, AppServerModule],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
