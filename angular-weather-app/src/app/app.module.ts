import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppRouteModule } from './app-route.module';

import { CitiesService } from './services/cities.service';
import { ForecastService } from './services/forecast.service';
import { HistoryService } from './services/history.service';

import { AppComponent } from './app.component';
import { DefaultCitiesComponent } from './default-cities/default-cities.component';
import { SelectedCitiesComponent } from './selected-cities/selected-cities.component';
import { HistoryComponent } from './history/history.component';
import { HistoryEntryComponent } from './history-entry/history-entry.component';
import { CurrentWeatherComponent } from './current-weather/current-weather.component';
import { HourlyForecastComponent } from './hourly-forecast/hourly-forecast.component';
import { DailyForecastComponent } from './daily-forecast/daily-forecast.component';

@NgModule({
  declarations: [
    AppComponent,
    DefaultCitiesComponent,
    SelectedCitiesComponent,
    HistoryComponent,
    HistoryEntryComponent,
    CurrentWeatherComponent,
    HourlyForecastComponent,
    DailyForecastComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRouteModule
  ],
  providers: [
    CitiesService,
    ForecastService,
    HistoryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
