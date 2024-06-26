let buttons = document.querySelectorAll(".carousel button");

buttons.forEach((button) => {
  button.addEventListener("click", (event) => {
    let inner = event.currentTarget
      .closest(".carousel")
      .querySelector(".carousel-inner");
    inner.classList.add("overflow-hidden");
    inner.classList.remove("overflow-visible");
    setTimeout(function () {
      inner.classList.add("overflow-visible");
      inner.classList.remove("overflow-hidden");
    }, 650);
  });
});
