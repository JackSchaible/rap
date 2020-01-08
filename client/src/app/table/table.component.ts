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

    ngOnInit() {
        window.onscroll = () => {
            const windowHeight =
                "innerHeight" in window
                    ? window.innerHeight
                    : document.documentElement.offsetHeight;

            const body = document.body;
            const html = document.documentElement;

            const docHeight = Math.max(
                body.scrollHeight,
                body.offsetHeight,
                html.clientHeight,
                html.scrollHeight,
                html.offsetHeight
            );
            const windowBottom = windowHeight + window.pageYOffset;
            if (windowBottom >= docHeight) {
                this.state.nextPage();
            }
        };
    }

    public toggleCollapse(flight: Flight) {
        flight.shouldCollapse = !flight.shouldCollapse;
    }
}
