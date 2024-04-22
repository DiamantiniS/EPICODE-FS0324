// const generateMainBoard = function () {
//     // funzione che crea il tabellone
// }

// const fillArray = function () {
//     // inserire in un array
// }

// const getRandomNum = function () {
//     // generare un numero random
// }

// const generateRandNumber = function () {
//     // stampare il numero
//     // associare la classe...
// }

// const generateUserBoards = function () {
//     // genera e gestisce le tabelline
// }

document.addEventListener("DOMContentLoaded", function() {
    creaTabellone();
    fillArray();
    estraiNumero(); // Spostato qui per assicurarsi che l'elemento "estraiNumero" sia stato caricato prima di aggiungere l'event listener
});

function creaTabellone() {
    var tabellone = document.getElementById("board");
    tabellone.innerHTML = "";
    for (var i = 1; i <= 100; i++) {
        var cella = document.createElement("div");
        cella.textContent = i;
        cella.classList.add("cell");
        cella.setAttribute("data-value", i); 
        tabellone.appendChild(cella);
    }
}

const num = [];

const fillArray = function () {
    for (var i = 1; i <= 100; i++) {
        num.push(i);
    }
}

const generateRandNumber = function () {
    const button = document.getElementById("estraiNumero");
    if (button) {
        button.addEventListener("click", getRandomNum);
    } else {
        console.error("Elemento 'estraiNumero' non trovato nel DOM.");
    }
};

function estraiNumero() {
    
    // Genera un numero casuale tra 1 e 100
    const numeroCasuale = Math.floor(Math.random() * 100) + 1;

    // Seleziona la cella corrispondente al numero casuale
    const cella = document.querySelector(`.cell[data-value="${numeroCasuale}"]`);

    // Se la cella esiste, aggiungi la classe "red"
    if (cella) {
        cella.classList.add("red");
    }
    e.preventedefault();
}