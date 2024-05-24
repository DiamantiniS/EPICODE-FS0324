import { Component } from '@angular/core';
import { Pc } from 'src/app/models/pc.interface';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
    pcs!: Pc[];
    randomPc: Pc[] = [];
    brands!: string[];

    ngOnInit(): void {
        this.getPcs();
    }

    async getPcs() {
        const res = await fetch('../../assets/db.json');
        const response = await res.json();
        this.pcs = response;
        console.log(this.pcs);
        this.brands = this.getBrands();
        this.getRandomPcs(2);
    }

    getBrands(): string[] {
        const marca: string[] = [];
        let marche: string = '';
        for (let i = 0; i < this.pcs.length; i++) {
            if (marche != this.pcs[i].brandLogo) {
                marche = this.pcs[i].brandLogo;
                marca.push(this.pcs[i].brandLogo);
            }
        }
        console.log(marca);
        return marca;
    }

    getRandomPcs(num: number) {
        const presenti: number[] = [];
        for (let i = 0; i < num; i++) {
            const indice = Math.floor(Math.random() * this.pcs.length);
            if (presenti.includes(indice)) this.getRandomPcs(num - i);
            presenti.push(indice);
            this.randomPc.push(this.pcs[indice]);
        }
        console.log(this.randomPc);
    }
}
