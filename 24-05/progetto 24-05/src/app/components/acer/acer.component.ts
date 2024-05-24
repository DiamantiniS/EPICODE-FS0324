import { Component } from '@angular/core';
import { Pc } from 'src/app/models/pc.interface';

@Component({
    selector: 'app-acer',
    templateUrl: './acer.component.html',
    styleUrls: ['./acer.component.scss'],
})
export class AcerComponent {
    pcs!: Pc[];
    brand!: string;
    brandLogo!: string

    ngOnInit(): void {
        this.getPcs();
    }

    async getPcs() {
        const res = await fetch('../../assets/db.json');
        const response = await res.json();
        this.pcs = response;
        this.pcs = this.pcs.filter((pcs) => pcs.brand === 'Acer')
        this.brandLogo = this.pcs[0].brandLogo;
        this.brand = this.pcs[0].brand;
    }
}
