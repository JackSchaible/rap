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
    private allFlights: Flight[];

    @computed
    get filteredFlights() {
        return this.allFlights.filter((flight: Flight): boolean => {
            if (
                !this.filterOptions.landed &&
                !this.filterOptions.reddit &&
                !this.filterOptions.reused
            )
                return true;

            let filterOut = false;

            if (this.filterOptions.landed) {
                if (!flight.landed) filterOut = true;
            } else {
                if (flight.landed) filterOut = true;
            }

            if (this.filterOptions.reddit) {
                if (!flight.reddit) filterOut = true;
            } else {
                if (flight.reddit) filterOut = true;
            }

            if (this.filterOptions.reused) {
                if (!flight.reused) filterOut = true;
            } else {
                if (flight.reused) filterOut = true;
            }

            return filterOut;
        });
    }

    @observable
    public state: State;

    @observable
    public filterOptions: FilterOptions;

    @computed
    get flights() {
        return this.filteredFlights;
    }

    constructor(private http: HttpService) {
        this.allFlights = [];
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
            (flights: any[]) =>
                (this.allFlights = flights.map((value: Flight) => {
                    value.launchDate = new Date(value.launchDate);
                    return value;
                })),
            () => {},
            () => (this.state = State.Default)
        );
    }
}
