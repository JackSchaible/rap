import { Component, OnInit, Input, Output } from "@angular/core";

@Component({
    selector: "app-checkbox",
    templateUrl: "./checkbox.component.html",
    styleUrls: ["./checkbox.component.scss"]
})
export class CheckboxComponent {
    @Input()
    @Output()
    public checked: boolean;

    @Input()
    public label: string;
}
