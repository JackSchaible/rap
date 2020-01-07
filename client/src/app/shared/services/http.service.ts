import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { delay } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: "root"
})
export class HttpService {
    constructor(private http: HttpClient) {}

    public getListing(): Observable<Array<any>> {
        return of([{}, {}, {}]).pipe(delay(1000));
        // return this.http.get<Array<any>>(`/flights`);
    }
}
