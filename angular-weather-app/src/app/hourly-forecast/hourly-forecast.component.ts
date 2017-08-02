import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { ForecastService } from '../services/forecast.service';

import { MultipleForecast } from '../models/multiple-forecst';
import { SingleForecast } from '../models/single-forecast';
import { DayForecast, SortedHourlyForecast } from '../models/sorted-hourly-forecast';

@Component({
	selector: 'app-hourly-forecast',
	templateUrl: './hourly-forecast.component.html',
	styleUrls: ['./hourly-forecast.component.css']
})
export class HourlyForecastComponent implements OnInit {

	constructor(
		private forecastService: ForecastService,
		private route: ActivatedRoute
	) { }

	forecast: SortedHourlyForecast;

	ngOnInit() {
		this.route.params
			.switchMap((params: Params) => this.forecastService.getSortedHourlyForecastInCity(params['city']))
			.subscribe(forecast => this.forecast = forecast);
  }
}
