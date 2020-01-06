import { Component } from "@angular/core";
import { StateService } from "./shared/services/state.service";

@Component({
    selector: "app-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.scss"]
})
export class AppComponent {
    constructor(private state: StateService) {}
}
