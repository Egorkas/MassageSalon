import { Component, OnInit } from '@angular/core';
import { MasseurService } from '../masseur.service';

@Component({
    selector: 'app-grid-masseurs',
    templateUrl: './grid-masseurs.component.html',
    styleUrls: ['./grid-masseurs.component.css']
})
export class GridMasseursComponent implements OnInit {

    constructor(private masseurService: MasseurService) { }

    MasseurList: any = [];

    ngOnInit(): void {
        this.refreshMasseurList();
    }

    refreshMasseurList() {
        this.masseurService.get().subscribe((data: any) => this.MasseurList = data);
    }

}
