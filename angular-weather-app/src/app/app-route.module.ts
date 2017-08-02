import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CurrentWeatherComponent } from './current-weather/current-weather.component';
import { HourlyForecastComponent } from './hourly-forecast/hourly-forecast.component';
import { DailyForecastComponent } from './daily-forecast/daily-forecast.component';
import { DefaultCitiesComponent } from './default-cities/default-cities.component';
import { SelectedCitiesComponent } from './selected-cities/selected-cities.component';
import { HistoryComponent } from './history/history.component';
import { HistoryEntryComponent } from './history-entry/history-entry.component';

const routes: Routes = [
  { path: 'current/:city', component: CurrentWeatherComponent},
  { path: 'hourly/:city', component: HourlyForecastComponent},
  { path: 'daily/:city', component: DailyForecastComponent},
  { path: 'history', component: HistoryComponent},
  { path: 'history/:id', component: HistoryEntryComponent},
  { path: 'cities', component: SelectedCitiesComponent}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRouteModule { }
