import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  template: `
  
  <form #form="ngForm" >
    <div class="form-group">
      <label for="name">Nome</label>
      <input name="name" ngModel id="name" class="form-control" type="text" >
    </div>
    <div class="form-group">
      <label for="email">email</label>
      <input name="email" ngModel id="email" class="form-control" type="email" >
    </div>
  </form>
  `,
  styles: [
  ]
})
export class NewUserPage implements OnInit {
@ViewChild('form') form!:NgForm
  constructor() { }

  ngOnInit(): void {
  }

  canDeactivate(){
    console.log(this.form)
    if (this.form.value.email == "" && this.form.value.name == "") {
      return true
    }
    return confirm('sei sicuro di voler cambiare pagina? perderai i dati inseriti')
  }

}
