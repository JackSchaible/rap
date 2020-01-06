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
                "rotating",
                style({ animation: "rotation 2s infinite linear" })
            ),
            transition("rotating => default", animate("400ms ease-out")),
            transition("default => rotating", animate("400ms ease-in"))
        ])
    ]
})
export class RefreshButtonComponent {
    constructor(private stateService: StateService) {}

    public handleClick() {
        this.stateService.refresh();
    }
}
