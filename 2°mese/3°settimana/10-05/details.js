const addressBarContent = new URLSearchParams(location.search) 
console.log(addressBarContent)
const eventId = addressBarContent.get('eventId')

const getEventData = function () {
  fetch(`https://striveschool-api.herokuapp.com/api/product/${eventId}`,{
    headers: {
    "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDllZjgxODQ0MjAwMTUzNzU4ODgiLCJpYXQiOjE3MTUzMjk1MTksImV4cCI6MTcxNjUzOTExOX0.5UnqSLiwETottFfZvZzuCEaI-U2HYFFx220D4lVQQM8"
    }
    })
    .then((response) => {
      if (response.ok) {
        return response.json()
      } else {
        throw new Error("Errore nel recupero dei dettagli dell'evento")
      }
    })
    .then((event) => {
      console.log('DETTAGLI RECUPERATI', event)
      document.getElementById('name').innerText = event.name
      document.getElementById('description').innerText = event.description
      document.getElementById('price').innerText = event.price + '€'
      document.getElementById('brand').innerText = event.brand
      document.getElementById('imageUrl').src = event.imageUrl
    })
    .catch((err) => {
      console.log('ERRORE', err)
    })
}

getEventData()


