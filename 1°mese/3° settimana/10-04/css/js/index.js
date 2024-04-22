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
  let dati = document.querySelectorall('dati')
  let campoDati = document.querySelectorall('#inserimento input')
  let nuovoDato = `<div class="dato"><span>${campoDati.value}<button><i class="far fa-trash-alt"></i></button></span></div>`
  dati.innerHTML += nuovoDato
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
    let btnCancella = document.querySelectorAll('.dato')
    for (let i = 0; i < btnCancella.length; i++) {
        btnCancella[i].addEventListener('click', function () {
        this.parentNode.remove()
      })
    }
  }
  
  