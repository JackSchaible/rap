import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { MobxAngularModule } from "mobx-angular";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { RefreshButtonComponent } from "./refresh-button/refresh-button.component";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    declarations: [AppComponent, RefreshButtonComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        MobxAngularModule,
        HttpClientModule,
        AppRoutingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
