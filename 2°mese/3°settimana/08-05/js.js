const createCard = () => {
    const row = document.getElementsByClassName("row");
    const card = 
      <div class="col">
        <div class="card" style="width: 18rem;">
          <img src=${element.img} class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">${element.title}</h5>
            <p class="card-text">${element.price}</p>
            <a href="#" id="discard" class="btn btn-primary">Scarta</a>
            <a href="#" id="buyNow" class="btn btn-primary">compra</a>
          </div>
        </div>
      </div>
    ;
    row.insertAdjacentHTML("beforeend",card);
  };