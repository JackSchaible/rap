import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Flight } from "../models/flight";

@Injectable({
    providedIn: "root"
})
export class HttpService {
    private baseUrl: string = environment.apiUrl + "/flights";

    constructor(private http: HttpClient) {}

    public getListing(): Observable<Array<Flight>> {
        return this.http.get<Array<Flight>>(this.baseUrl);
    }
}
