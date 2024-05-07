const currentYear = new Date().getFullYear();
document.getElementById("year").innerText = currentYear;

const textAreaTag = document.getElementById("content");

const save = function () {
  console.log("premuto salva!");

  const textAreaContent = textAreaTag.value;
  console.log(textAreaContent);

  localStorage.setItem("notepad-content", textAreaContent);

  toggleLoadButton("enable");
};

const load = function () {
  console.log("premuto carica!");
  const savedValue = localStorage.getItem("notepad-content");
  textAreaTag.value = savedValue;
};

const loadButton = document
  .getElementsByClassName("btn-info")[0]
  .addEventListener("click", load);

const toggleLoadButton = function (str) {
  if (str === "enable") {
    document.getElementsByClassName("btn-info")[0].removeAttribute("disabled");
  } else {
    document
      .getElementsByClassName("btn-info")[0]
      .setAttribute("disabled", true);
  }
};

if (localStorage.getItem("notepad-content")) {
  toggleLoadButton("enable");
}

const deleteMemory = function () {
  localStorage.removeItem("notepad-content");

  toggleLoadButton("disable");
};
