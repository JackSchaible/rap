import { Component } from "@angular/core";
import {
    trigger,
    state,
    style,
    animate,
    transition
} from "@angular/animations";
import { StateService } from "../shared/services/state.service";

@Component({
    selector: "app-refresh-button",
    templateUrl: "./refresh-button.component.html",
    styleUrls: ["./refresh-button.component.scss"],
    animations: [
        trigger("rotatingState", [
            state("default", style({ animation: "" })),
            state(
                "loading",
                style({ animation: "rotation 2s infinite linear" })
            ),
            transition("loading => default", animate("400ms ease-out")),
            transition("default => loading", animate("400ms ease-in"))
        ])
    ]
})
export class RefreshButtonComponent {
    constructor(public stateService: StateService) {}

    public handleClick() {
        this.stateService.refresh();
    }
}
