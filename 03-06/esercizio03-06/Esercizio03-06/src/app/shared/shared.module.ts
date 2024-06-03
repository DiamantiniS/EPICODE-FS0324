import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostCardComponent } from './components/post-card.component';
import { MaiuscoloPipe } from './pipes/maiuscolo.pipe';
import { HighlightDirective } from './directives/highlight.directive';
import { PostDetailsPage } from './post-details.page';

const Components =[
  PostCardComponent,
  MaiuscoloPipe,
  HighlightDirective,
  PostDetailsPage
]

@NgModule({
  declarations: [
   ...Components
  ],
  imports: [
    CommonModule
  ],
  exports:[...Components]
})
export class SharedModule { }
