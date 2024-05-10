document.getElementById("year").innerText = new Date().getFullYear();

const generateProductCards = function (productsArray) {
  const row = document.getElementById("events-row");
  productsArray.forEach((product) => {
    const newCol = document.createElement("div");
    newCol.classList.add("col");
    newCol.innerHTML = `
      <div class="card h-100 d-flex flex-column">
        <img src="${product.imageUrl}" class="card-img-top" alt="...">
        <div class="card-body d-flex flex-column justify-content-around">
          <h5 class="card-title">${product.name}</h5>
          <p class="card-text">${product.description}</p>
          <p class="card-text">${product.brand}</p>
          <div class="d-flex justify-content-between">
            <button class="btn btn-primary">${product.price}€</button>
            <a href="details.html?eventId=${product._id}" class="btn btn-info">INFO</a>
            <button id="edit-button-${product._id}"  class="btn btn-warning" data-event-id="${product._id}">MODIFICA</button>
          </div>
        </div>
      </div>
      `;
    row.appendChild(newCol);
  });
};

const getEvents = function () {
  fetch("https://striveschool-api.herokuapp.com/api/product/", {
    headers: {
      Authorization:
        "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NjNkZDllZjgxODQ0MjAwMTUzNzU4ODgiLCJpYXQiOjE3MTUzMjk1MTksImV4cCI6MTcxNjUzOTExOX0.5UnqSLiwETottFfZvZzuCEaI-U2HYFFx220D4lVQQM8",
    },
  })
    .then((response) => {
      if (response.ok) {
        console.log(response);
        return response.json();
      } else {
        throw new Error("Errore nella risposta del server");
      }
    })
    .then((array) => {
      console.log("ARRAY!", array);

      generateProductCards(array);
    })
    .catch((err) => {
      console.log("ERRORE!", err);
    });
};

getEvents();

const editButtons = document.getElementsByClassName('btn-warning')
Array.from(editButtons).forEach(function (button) {
  button.addEventListener("click", function () {
    location.assign(`backoffice.html?eventId=${eventId}`);
  });
});

const editCard = function () {};