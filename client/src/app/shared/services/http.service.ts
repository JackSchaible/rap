import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: "root"
})
export class HttpService {
    constructor(private http: HttpClient) {}

    public getListing(): Observable<Array<any>> {
        return this.http.get<Array<any>>(`/flights`);
    }
}
