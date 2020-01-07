import { Component, OnInit } from "@angular/core";
import { StateService } from "../shared/services/state.service";

@Component({
    selector: "app-table",
    templateUrl: "./table.component.html",
    styleUrls: ["./table.component.scss"]
})
export class TableComponent implements OnInit {
    constructor(public state: StateService) {}

    ngOnInit() {}
}
