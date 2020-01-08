import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { observable, action, computed } from "mobx-angular";
import { State } from "../models/enums";
import { Flight } from "../models/flight";
import { FilterOptions } from "../models/filterOptions";
import { ToastrService } from "ngx-toastr";

@Injectable({
    providedIn: "root"
})
export class StateService {
    @computed
    public get flights(): Flight[] {
        let flights: Flight[] = this.allFlights;

        // Sort the flights
        flights = flights.sort((a: Flight, b: Flight): number => {
            return a.id - b.id;
        });

        // Paginate the flights
        flights = flights.slice(0, this.pageSize * this.currentPage);

        return flights;
    }

    @observable
    public state: State;

    @observable
    public filterOptions: FilterOptions;

    private allFlights: Flight[];
    private pageSize = 10;
    private currentPage = 1;

    constructor(private http: HttpService, private toastr: ToastrService) {
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
            (flights: Flight[]) => this.handleResults(flights),
            () => this.handleError(),
            () => (this.state = State.Default)
        );
    }

    @action()
    public changeFilter(property: string) {
        this.state = State.Loading;
        this.filterOptions[property] = !this.filterOptions[property];

        this.http.filter(this.filterOptions).subscribe(
            (flights: Flight[]) => this.handleResults(flights),
            () => this.handleError(),
            () => (this.state = State.Default)
        );
    }

    @action()
    public nextPage() {
        this.currentPage++;
    }

    // Handle the results specially so the DOM doesn't have to refresh everytime and re-load all the badge images
    private handleResults(flights: Flight[]) {
        // Remove flights that aren't in the filter list
        this.allFlights = this.flights.filter((flight: Flight) =>
            flights.find(
                (flightToFind: Flight) => flightToFind.id === flight.id
            )
        );

        // Don't add flights we already have
        flights = flights.filter(
            (flight: Flight) =>
                !this.flights.find(
                    (flightToFind: Flight) => flightToFind.id === flight.id
                )
        );

        // Add the new flights to the list
        this.allFlights = this.flights.concat(
            flights.map((value: Flight) => {
                value.launchDate = new Date(value.launchDate);
                return value;
            })
        );
    }

    private handleError() {
        this.toastr.error(
            "An error occurred fetching data from the server. Ensure the sever is running and try again."
        );
        this.state = State.Default;
    }
}
