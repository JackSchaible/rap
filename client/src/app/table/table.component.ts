import { Component, OnInit } from "@angular/core";
import { StateService } from "../shared/services/state.service";
import { Flight } from "../shared/models/flight";

@Component({
    selector: "app-table",
    templateUrl: "./table.component.html",
    styleUrls: ["./table.component.scss"]
})
export class TableComponent implements OnInit {
    constructor(public state: StateService) {}

    ngOnInit() {}

    public toggleCollapse(flight: Flight) {
        flight.shouldCollapse = !flight.shouldCollapse;
    }
}
