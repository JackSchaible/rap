import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { observable, action, computed } from "mobx-angular";
import { State } from "../models/enums";
import { Flight } from "../models/flight";
import { FilterOptions } from "../models/filterOptions";

@Injectable({
    providedIn: "root"
})
export class StateService {
    @observable
    public flights: Flight[];

    @observable
    public state: State;

    @observable
    public filterOptions: FilterOptions;

    constructor(private http: HttpService) {
        this.flights = [];
        this.state = State.Default;
        this.filterOptions = {
            landed: false,
            reddit: false,
            reused: false
        };
    }

    @action()
    public refresh() {
        this.state = State.Loading;
        this.http.getListing().subscribe(
            (flights: Flight[]) => this.handleResults(flights),
            //TODO: handle errors
            () => {},
            () => (this.state = State.Default)
        );
    }

    @action()
    public changeFilter(property: string, on: boolean) {
        this.state = State.Loading;
        this.filterOptions[property] = on;

        this.http.filter(this.filterOptions).subscribe(
            (flights: Flight[]) => this.handleResults(flights),
            () => {},
            () => (this.state = State.Default)
        );
    }

    private handleResults(flights: Flight[]) {
        this.flights = flights.map((value: Flight) => {
            value.launchDate = new Date(value.launchDate);
            return value;
        });
    }
}
