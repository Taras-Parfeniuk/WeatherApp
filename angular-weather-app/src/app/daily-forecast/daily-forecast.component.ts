import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { ForecastService } from '../services/forecast.service';

import { MultipleForecast } from '../models/multiple-forecst';

@Component({
	selector: 'app-daily-forecast',
	templateUrl: './daily-forecast.component.html',
	styleUrls: ['./daily-forecast.component.css']
})
export class DailyForecastComponent implements OnInit {

	constructor(
		private forecastService: ForecastService,
		private route: ActivatedRoute
	) { }

	forecast: MultipleForecast;

	ngOnInit() {
		this.route.params
			.switchMap((params: Params) => this.forecastService.getDailyForecastInCity(params['city']))
			.subscribe(forecast => this.forecast = forecast);
	}
}
