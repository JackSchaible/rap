import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { MobxAngularModule } from "mobx-angular";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { RefreshButtonComponent } from "./refresh-button/refresh-button.component";
import { HttpClientModule } from "@angular/common/http";
import { CheckboxComponent } from "./checkbox/checkbox.component";
import { FormsModule } from "@angular/forms";
import { TableComponent } from './table/table.component';

@NgModule({
    declarations: [AppComponent, RefreshButtonComponent, CheckboxComponent, TableComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        MobxAngularModule,
        HttpClientModule,
        FormsModule,
        AppRoutingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
