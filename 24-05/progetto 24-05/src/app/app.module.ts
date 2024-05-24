import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Route } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AsusComponent } from './components/asus/asus.component';
import { AcerComponent } from './components/acer/acer.component';
import { LenovoComponent } from './components/lenovo/lenovo.component';
import { FooterComponent } from './components/footer/footer.component';

const routes: Route[] = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'asus',
        component: AsusComponent
    },
    {
        path: 'acer',
        component: AcerComponent
    },
    {
        path: 'lenovo',
        component: LenovoComponent
    },
    {
        path: '**',
        redirectTo: ''
    }
]

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavbarComponent,
        AsusComponent,
        AcerComponent,
        LenovoComponent,
        FooterComponent,
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(routes)
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
