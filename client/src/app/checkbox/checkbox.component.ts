import { Component, Input } from "@angular/core";
import { StateService } from "../shared/services/state.service";

@Component({
    selector: "app-checkbox",
    templateUrl: "./checkbox.component.html",
    styleUrls: ["./checkbox.component.scss"]
})
export class CheckboxComponent {
    @Input()
    public propertyToFilter: string;

    @Input()
    public label: string;

    constructor(private state: StateService) {}

    public change() {
        this.state.changeFilter(this.propertyToFilter);
    }
}
