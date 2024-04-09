/* ESERCIZIO 1
  Scrivi una funzione per concatenare due stringhe ricevute come parametri, selezionando solamente i primi 2 caratteri della
  prima e gli ultimi 3 della seconda. Converti la stringa risultante in maiuscolo e mostrala con un console.log().
*/
function concatenaStringhe(str1, str2) {
  let primoSegmento = str1.slice(0, 2);
  let secondoSegmento = str2.slice(-3);
  let risultato = primoSegmento.concat(secondoSegmento);
  risultato = risultato.toUpperCase();
  console.log(risultato);
}


concatenaStringhe("hello", "world");
concatenaStringhe("foo", "bar");


 
/* ESERCIZIO 2 (for)
  Scrivi una funzione che torni un array di 10 elementi; ognuno di essi deve essere un valore random compreso tra 0 e 100 (incluso).
*/
function array() {
  let array1 = [];
  for (let i = 0; i < 10; i++) {
      array1[i] = Math.ceil(Math.random() * 100);
  }
  return array1
}
console.log(array());

/* ESERCIZIO 3 (filter)
  Scrivi una funzione per ricavare solamente i valori PARI da un array composto da soli valori numerici
*/
function filtraPari(arrayNumerico) {
  let valoriPari = arrayNumerico.filter(numero => numero % 2 === 0);
  return valoriPari;
}
let arrayNumerico = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let valoriPari = filtraPari(arrayNumerico);
console.log(valoriPari);

/* ESERCIZIO 4 (forEach)
  Scrivi una funzione per sommare i numeri contenuti in un array
*/
function sommaArray(arrayNum) {
  let somma = 0;
  arrayNum.forEach(numero => {
      somma += numero;
  });
  return somma;
}

let arrayNum = [1, 2, 3, 4, 5, 7];
let risultatoSomma = sommaArray(arrayNum);
console.log("La somma degli elementi dell'array è:", risultatoSomma);


/* ESERCIZIO 5 (reduce)
  Scrivi una funzione per sommare i numeri contenuti in un array
*/
function sommaArray(arrayNum2) {
  
  let somma = arrayNum2.reduce((acc, numero) => acc + numero, 0);
  return somma;
}

let arrayNum2 = [1, 2, 3, 4, 5, 7];
let vettore = sommaArray(arrayNum2);
console.log("La somma degli elementi dell'array è:", vettore);

/* ESERCIZIO 6 (map)
  Scrivi una funzione che, dato un array di soli numeri e un numero n come parametri, ritorni un secondo array con tutti i valori del precedente incrementati di n
*/
function incrementaArray(arrayInput, incremento) {
  let arrayIncrementato = arrayInput.map(numero => numero + incremento);
  return arrayIncrementato;
}

let arrayInput = [1, 2, 3, 4, 5];
let incremento = 3;
let arrayIncrementato = incrementaArray(arrayInput, incremento);
console.log("Array incrementato:", arrayIncrementato);

/* ESERCIZIO 7 (map)
  Scrivi una funzione che, dato un array di stringhe, ritorni un nuovo array contenente le lunghezze delle rispettive stringhe dell'array di partenza
  es.: ["EPICODE", "is", "great"] => [7, 2, 5]
*/
function lunghezzaStringhe(arrayStringhe) {
  let lunghezze = arrayStringhe.map(stringa => stringa.length);
  return lunghezze;
}

let arrayStringhe = ["BELLO", "de", "casa"];
let lunghezze = lunghezzaStringhe(arrayStringhe);
console.log("Lunghezze delle stringhe:", lunghezze);

/* ESERCIZIO 8 (forEach o for)
  Scrivi una funzione per creare un array contenente tutti i valori DISPARI da 1 a 99.
*/
function numeriDispari() {
  let arrayDispari = [];

  for (let i = 1; i <= 99; i++) {
      if (i % 2 !== 0) {
          arrayDispari.push(i);
      }
  }

  return arrayDispari;
}

let arrayDispari = numeriDispari();
console.log("Numeri dispari da 1 a 99:", arrayDispari);


/* Questo array di film verrà usato negli esercizi a seguire. Non modificarlo e scorri oltre per riprendere gli esercizi :) */
const movies = [
  {
    Title: 'The Lord of the Rings: The Fellowship of the Ring',
    Year: '2001',
    imdbID: 'tt0120737',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings: The Return of the King',
    Year: '2003',
    imdbID: 'tt0167260',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings: The Two Towers',
    Year: '2002',
    imdbID: 'tt0167261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNGE5MzIyNTAtNWFlMC00NDA2LWJiMjItMjc4Yjg1OWM5NzhhXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of War',
    Year: '2005',
    imdbID: 'tt0399295',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTYzZWE3MDAtZjZkMi00MzhlLTlhZDUtNmI2Zjg3OWVlZWI0XkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'Lords of Dogtown',
    Year: '2005',
    imdbID: 'tt0355702',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDBhNGJlOTAtM2ExNi00NmEzLWFmZTQtYTZhYTRlNjJjODhmXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg',
  },
  {
    Title: 'The Lord of the Rings',
    Year: '1978',
    imdbID: 'tt0077869',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGMyNWJhZmYtNGQxYi00Y2ZjLWJmNjktNTgzZWJjOTg4YjM3L2ltYWdlXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1990',
    imdbID: 'tt0100054',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOTI2NTQyODk0M15BMl5BanBnXkFtZTcwNTQ3NDk0NA@@._V1_SX300.jpg',
  },
  {
    Title: 'The Lords of Salem',
    Year: '2012',
    imdbID: 'tt1731697',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjA2NTc5Njc4MV5BMl5BanBnXkFtZTcwNTYzMTcwOQ@@._V1_SX300.jpg',
  },
  {
    Title: 'Greystoke: The Legend of Tarzan, Lord of the Apes',
    Year: '1984',
    imdbID: 'tt0087365',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM5MzcwOTg4MF5BMl5BanBnXkFtZTgwOTQwMzQxMDE@._V1_SX300.jpg',
  },
  {
    Title: 'Lord of the Flies',
    Year: '1963',
    imdbID: 'tt0057261',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BOGEwYTlhMTgtODBlNC00ZjgzLTk1ZmEtNmNkMTEwYTZiM2Y0XkEyXkFqcGdeQXVyMzU4Nzk4MDI@._V1_SX300.jpg',
  },
  {
    Title: 'The Avengers',
    Year: '2012',
    imdbID: 'tt0848228',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Infinity War',
    Year: '2018',
    imdbID: 'tt4154756',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Age of Ultron',
    Year: '2015',
    imdbID: 'tt2395427',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTM4OGJmNWMtOTM4Ni00NTE3LTg3MDItZmQxYjc4N2JhNmUxXkEyXkFqcGdeQXVyNTgzMDMzMTg@._V1_SX300.jpg',
  },
  {
    Title: 'Avengers: Endgame',
    Year: '2019',
    imdbID: 'tt4154796',
    Type: 'movie',
    Poster:
      'https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SX300.jpg',
  },
]

/* ESERCIZIO 9 (forEach)
  Scrivi una funzione per trovare il film più vecchio nell'array fornito.
*/
function trovaFilmPiuVecchio(arrayFilm) {
  let filmPiuVecchio = null;
  
  arrayFilm.forEach(film => {
      if (!filmPiuVecchio || parseInt(film.Year) < parseInt(filmPiuVecchio.Year)) {
          filmPiuVecchio = film;
      }
  });
  
  return filmPiuVecchio;
}

let filmPiuVecchio = trovaFilmPiuVecchio(movies);
console.log("Il film più vecchio è:", filmPiuVecchio);

/* ESERCIZIO 10
  Scrivi una funzione per ottenere il numero di film contenuti nell'array fornito.
*/
function contaFilm(arrayFilm) {
  return arrayFilm.length;
}

let numeroDiFilm = contaFilm(movies);
console.log("Il numero di film è:", numeroDiFilm);

/* ESERCIZIO 11 (map)
  Scrivi una funzione per creare un array con solamente i titoli dei film contenuti nell'array fornito.
*/
function ottieniTitoli(arrayFilm) {
  let titoli = arrayFilm.map(film => film.Title);
  return titoli;
}

let titoliDeiFilm = ottieniTitoli(movies);
console.log("Titoli dei film:", titoliDeiFilm);

/* ESERCIZIO 12 (filter)
  Scrivi una funzione per ottenere dall'array fornito solamente i film usciti nel millennio corrente.
*/
function filmDelMillennioCorrente(arrayFilm) {
  const annoCorrente = new Date().getFullYear();

  let filmMillennioCorrente = arrayFilm.filter(film => {
      return parseInt(film.Year) >= annoCorrente - 20 && parseInt(film.Year) <= annoCorrente;
  });

  return filmMillennioCorrente;
}

let filmMillennioCorrente = filmDelMillennioCorrente(movies);
console.log("Film del millennio corrente:", filmMillennioCorrente);

/* ESERCIZIO 13 (reduce)
  Scrivi una funzione per calcolare la somma di tutti gli anni in cui sono stati prodotti i film contenuti nell'array fornito.
*/
function sommaAnniProduzione(arrayFilm) {
  let sommaAnni = arrayFilm.reduce((acc, film) => acc + parseInt(film.Year), 0);
  return sommaAnni;
}

let sommaAnni = sommaAnniProduzione(movies);
console.log("Somma degli anni di produzione:", sommaAnni);

/* ESERCIZIO 14 (find)
  Scrivi una funzione per ottenere dall'array fornito uno specifico film (la funzione riceve un imdbID come parametro).
*/


/* ESERCIZIO 15 (findIndex)
  Scrivi una funzione per ottenere dall'array fornito l'indice del primo film uscito nell'anno fornito come parametro.
*/


