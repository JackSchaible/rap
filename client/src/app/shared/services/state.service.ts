import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { observable, action } from "mobx-angular";
import { State } from "../models/enums";
import { Flight } from "../models/flight";

@Injectable({
    providedIn: "root"
})
export class StateService {
    constructor(private http: HttpService) {
        this.flights = [];
        //this.state = State.Default;
    }

    @observable()
    public flights: Flight[];

    // @observable()
    // public state: State;

    @action()
    public refresh() {
        //this.state = State.Loading;

        this.http.getListing().subscribe(
            (flights: any[]) => (this.flights = flights),
            () => {}
            //  () => (this.state = State.Default)
        );
    }
}
