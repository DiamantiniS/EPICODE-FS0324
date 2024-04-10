const handleSubmit = function (e) {
    e.preventDefault()
    aggiungi()
    completato()
    eliminato()
  }
window.onload = function () {
    let form = document.querySelector('form')
    form.addEventListener('submit', handleSubmit)
}
    
const aggiungi = function () {
  let dati = document.querySelector('#dati')
  let campoDati = document.querySelector('#inserimento input')
  let nuovoDato = `<div class="dato"><span>${campoDati.value}</span><button class="cancella"><i class="far fa-trash-alt"></i></button></div>`
  dati.innerHTML += nuovoDato
  campoDati.value = ''
}

const completato = function () {
  let tuttiDati = document.querySelectorAll('.dato')
  for (let i = 0; i < tuttiDati.length; i++) {
    tuttiDati[i].addEventListener('click', function () {
      this.classList.toggle('completato')
    })
  }
}

const eliminato = function () {
    let btnCancella = document.querySelectorAll('.cancella')
    for (let i = 0; i < btnCancella.length; i++) {
        btnCancella[i].addEventListener('click', function () {
        this.parentNode.remove()
      })
    }
  }
  
  