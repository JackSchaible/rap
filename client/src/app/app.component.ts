import { Component, OnInit } from "@angular/core";
import { StateService } from "./shared/services/state.service";

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
    constructor(public state: StateService) {}

    public ngOnInit() {
        this.state.refresh();
    }
}
