import { Component } from '@angular/core';
import { Pc } from 'src/app/models/pc.interface';

@Component({
    selector: 'app-lenovo',
    templateUrl: './lenovo.component.html',
    styleUrls: ['./lenovo.component.scss'],
})
export class LenovoComponent {
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
        this.pcs = this.pcs.filter((pc) => pc.brand === 'Lenovo')
        this.brandLogo = this.pcs[0].brandLogo;
        this.brand = this.pcs[0].brand;
    }
}
