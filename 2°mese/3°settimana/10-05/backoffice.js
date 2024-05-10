class Product {
  constructor(_name, _description, _price, _brand, _imageUrl ) {
    this.name = _name;
    this.description = _description;
    this.price = _price;
    this.brand = _brand;
    this.imageUrl = _imageUrl;
  }
}

const addressBarContent = new URLSearchParams(location.search); 
const eventId = addressBarContent.get('eventId'); 
console.log('EVENTID?', eventId);

let eventToModify;

const getEventData = function () {
  fetch(`https://striveschool-api.herokuapp.com/api/product/${eventId}`, {
    headers: {
      "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDllZjgxODQ0MjAwMTUzNzU4ODgiLCJpYXQiOjE3MTUzMjk1MTksImV4cCI6MTcxNjUzOTExOX0.5UnqSLiwETottFfZvZzuCEaI-U2HYFFx220D4lVQQM8"
    }
  })
  .then((response) => {
    if (response.ok) {
      return response.json();
    } else {
      throw new Error("Errore nel recupero dei dettagli dell'evento");
    }
  })
  .then((event) => {
    console.log('DETTAGLI RECUPERATI', event);
    document.getElementById('name').value = event.name;
    document.getElementById('description').value = event.description;
    document.getElementById('price').value = event.price; 
    document.getElementById('brand').value = event.brand;
    document.getElementById('imageUrl').value = event.imageUrl;
    
    eventToModify = event;
  })
  .catch((err) => {
    console.log('ERRORE', err);
  });
};

if (eventId) {
  getEventData();
  document.getElementsByClassName('btn-primary')[0].innerText = 'MODIFICA!';
  document.getElementById("delete").classList.remove("d-none");
  document.getElementById("delete").classList.add("d-block");
  console.log('DETTAGLI RECUPERATI', eventId);
}

document.getElementById('clear-form').addEventListener('click', function () {
  document.getElementById('name').value = '';
  document.getElementById('description').value = '';
  document.getElementById('price').value = ''; 
  document.getElementById('brand').value = '';
  document.getElementById('imageUrl').value = '';
});

const submitEvent = function (e) {
  e.preventDefault();
  const nameInput = document.getElementById('name');
  const descriptionInput = document.getElementById('description');
  const priceInput = document.getElementById('price'); 
  const brandInput = document.getElementById('brand');
  const imageUrlInput = document.getElementById('imageUrl');
  const productFromForm = new Product(
    nameInput.value,
    descriptionInput.value,
    priceInput.value,
    brandInput.value,
    imageUrlInput.value
  );

  console.log('PRODOTTO DA INVIARE ALLE API', productFromForm);
  let URL = 'https://striveschool-api.herokuapp.com/api/product';
  let methodToUse = 'POST';

  if (eventId) {
    URL = `https://striveschool-api.herokuapp.com/api/product/${eventToModify._id}`;
    methodToUse = 'PUT';
  }

  fetch(URL,  {
    method: methodToUse,
    body: JSON.stringify(productFromForm),
    headers: {
      'Content-type': 'application/json',
      'Authorization': "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDllZjgxODQ0MjAwMTUzNzU4ODgiLCJpYXQiOjE3MTUzMjk1MTksImV4cCI6MTcxNjUzOTExOX0.5UnqSLiwETottFfZvZzuCEaI-U2HYFFx220D4lVQQM8"
    },
  })
  .then((response) => {
    if (response.ok) {
      alert(`Prodotto ${eventId ? 'modificato' : 'creato'}!`);
    } else {
      throw new Error('Errore nel salvataggio della risorsa');
    }
  })
  .catch((err) => {
    console.log('ERRORE', err);
    alert(err);
  });
};

document.getElementById('event-form').addEventListener('submit', submitEvent);

const deleteEvent = function () {
  fetch(`https://striveschool-api.herokuapp.com/api/product/${eventId}`, {
    method: 'DELETE',
    headers: {
      "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDllZjgxODQ0MjAwMTUzNzU4ODgiLCJpYXQiOjE3MTUzMjk1MTksImV4cCI6MTcxNjUzOTExOX0.5UnqSLiwETottFfZvZzuCEaI-U2HYFFx220D4lVQQM8"
      },
    
  })
    .then((response) => {
      if (response.ok) {
        alert('RISORSA ELIMINATA')
        location.assign('index.html') 
      } else {
        alert('ERRORE - RISORSA NON ELIMINATA')
      }
    })
    .catch((err) => {
      console.log('ERR', err)
    })
}