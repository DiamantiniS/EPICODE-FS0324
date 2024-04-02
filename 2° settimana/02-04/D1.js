/*
REGOLE
- Tutte le risposte devono essere scritte in JavaScript
- Puoi usare Google / StackOverflow ma solo quanto ritieni di aver bisogno di qualcosa che non è stato spiegato a lezione
- Puoi testare il tuo codice in un file separato, o de-commentando un esercizio alla volta
- Per visualizzare l'output, lancia il file HTML a cui è collegato e apri la console dagli strumenti di sviluppo del browser. 
- Utilizza dei console.log() per testare le tue variabili e/o i risultati delle espressioni che stai creando.
*/

/* ESERCIZIO 1
 Elenca e descrivi i principali datatype in JavaScript. Prova a spiegarli come se volessi farli comprendere a un bambino.
*/

/* SCRIVI QUI LA TUA RISPOSTA */

/*Numero:
I numeri sono come mattoncini che usiamo per contare o misurare le cose. Possono essere interi o decimali e li usiamo per fare calcoli o rappresentare quantità.

Stringa:
Le stringhe sono sequenze di caratteri, come lettere, numeri o simboli, racchiuse tra virgolette. Sono utilizzate per rappresentare testo, come parole, frasi o anche codice.

Booleano:
I booleani sono come interruttori che possono essere "accesi" (true) o "spenti" (false). Li usiamo per rappresentare condizioni logiche, come vero o falso, attivo o disattivo.

Null:
Null è un valore speciale che indica la mancanza intenzionale di un valore. È diverso da zero o vuoto, indica che una variabile è stata dichiarata ma non ha un valore assegnato.

Undefined:
Undefined indica che una variabile è stata dichiarata ma a cui volutamente non è stato dato un valore. È come se non avesse un valore definito al momento.
*/


/* ESERCIZIO 2
 Crea una variable chiamata "myName" e assegna ad essa il tuo nome, sotto forma di stringa.
*/

/* SCRIVI QUI LA TUA RISPOSTA */

var myName = "Simone";
console.log(myName);


/* ESERCIZIO 3
 Scrivi il codice necessario ad effettuare un addizione (una somma) dei numeri 12 e 20.
*/

/* SCRIVI QUI LA TUA RISPOSTA */

var numero1 = 12;
var numero2 = 20;
var risultato = numero1 + numero2;
console.log("Totale:", risultato);


/* ESERCIZIO 4
 Crea una variable di nome "x" e assegna ad essa il numero 12.
*/

/* SCRIVI QUI LA TUA RISPOSTA */

var x = 12;
console.log(x);


/* ESERCIZIO 5
  Riassegna un nuovo valore alla variabile "myName" già esistente: il tuo cognome.
  Dimostra l'impossibilità di riassegnare un valore ad una variabile dichiarata con il costrutto const.
*/

/* SCRIVI QUI LA TUA RISPOSTA */

var myName = "Simone Diamantini";
console.log(myName); 

/*const piGreco = 3.14; l'ho messo in questo modo per vedere gli elementi successivi visti che senno legge l'errore e si ferma!
piGreco = 3.14159; 
console.log(piGreco);


/* ESERCIZIO 6
 Esegui una sottrazione tra i numeri 4 e la variable "x" appena dichiarata (che contiene il numero 12).
*/

/* SCRIVI QUI LA TUA RISPOSTA */

var x = 12;
var NuovoTotale = x - 4;
console.log("Il Nuovo Totale è:", NuovoTotale);


/* ESERCIZIO 7
 Crea due variabili: "name1" e "name2". Assegna a name1 la stringa "john", e assegna a name2 la stringa "John" (con la J maiuscola!).
 Verifica che name1 sia diversa da name2 (suggerimento: è la stessa cosa di verificare che la loro uguaglianza sia falsa).
 EXTRA: verifica che la loro uguaglianza diventi true se entrambe vengono trasformate in lowercase (senza cambiare il valore di name2!).
*/

/* SCRIVI QUI LA TUA RISPOSTA */
 
var name1 = "john";
var name2 = "John";
var Diverso = name1 !== name2;
console.log("I due nomi sono diversi:", Diverso);
var Uguali = name1 === name2.toLowerCase();
console.log("I due nomi sono uguali:", Uguali);
