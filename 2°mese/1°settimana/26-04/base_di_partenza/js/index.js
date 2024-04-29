window.addEventListener("scroll", (e) => {
  let navbar = document.querySelector("#navbar");
  let navButton = document.querySelector(".nav-button");
  e.preventDefault();
  if (window.scrollY >= 350) {
    navbar.classList.add("bg-white");
    navButton.classList.add("bg-green");
  } else {
    navbar.classList.remove("bg-white");
    navButton.classList.remove("bg-green");
    navbar.classList.add("bg-yellow");
  }
});

let animation = document.querySelectorAll(".m-svg svg g");

function selectLetter(i) {
  return i[Math.floor(Math.random() * i.length)];
}

function animatedM() {
  let switchTrue = selectLetter(Array.from(animation));
  if (switchTrue.classList.contains("m")) {
    switchTrue.classList.remove("m");
  } else {
    switchTrue.classList.add("m");
  }
}

setInterval(animatedM, 8);
