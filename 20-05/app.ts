let _costoChiamata: number = 0.2;

interface Smartphone {
  _credito: number;
  _numeroChiamate: number;
}

class User implements Smartphone {
  // Smartphone
  _credito: number;
  _numeroChiamate: number;

  // User
  _nome: string;
  _cognome: string;

  constructor(
    nome: string,
    cognome: string,
    credito: number = 0,
    numeroChiamate: number = 0
  ) {
    this._nome = nome;
    this._cognome = cognome;
    this._credito = credito;
    this._numeroChiamate = numeroChiamate;
  }

  ricarica(amount: number): void {
    this._credito += amount;
    console.log(
      `Credito ricaricato: ${amount}€. Credito residuo ${this._credito}€`
    );
  }

  chiamata(duration: number): void {
    if (this._credito >= _costoChiamata) {
      this._numeroChiamate += duration;
      this._credito -= duration * _costoChiamata;
      console.log(
        `Hai effettuato una chiamata di ${duration}'. Il costo della chiamata è stato di ${
          duration * _costoChiamata
        }.`
      );
    } else {
      console.log(
        `Il tuo credito è di soli ${this._credito}€. Pezzente vatti a fare una ricarica.`
      );
    }
  }

  chiama404(): void {
    console.log(this._credito);
  }

  getNumeroChiamata(minutesInCall: number): void {
    console.log(this._numeroChiamate);
  }

  azzeraChiamate(): void {
    this._numeroChiamate = 0;
    console.log(`Chiamate azzerate`);
  }
}
