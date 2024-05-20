"use strict";
let _costoChiamata = 0.2;
class User {
    constructor(nome, cognome, credito = 0, numeroChiamate = 0) {
        this._nome = nome;
        this._cognome = cognome;
        this._credito = credito;
        this._numeroChiamate = numeroChiamate;
    }
    ricarica(amount) {
        this._credito += amount;
        console.log(`Credito ricaricato: ${amount}€. Credito residuo ${this._credito}€`);
    }
    chiamata(duration) {
        if (this._credito >= _costoChiamata) {
            this._numeroChiamate += duration;
            this._credito -= duration * _costoChiamata;
            console.log(`Hai effettuato una chiamata di ${duration}'. Il costo della chiamata è stato di ${duration * _costoChiamata}.`);
        }
        else {
            console.log(`Il tuo credito è di soli ${this._credito}€. Pezzente vatti a fare una ricarica.`);
        }
    }
    chiama404() {
        console.log(this._credito);
    }
    getNumeroChiamata(minutesInCall) {
        console.log(this._numeroChiamate);
    }
    azzeraChiamate() {
        this._numeroChiamate = 0;
        console.log(`Chiamate azzerate`);
    }
}
