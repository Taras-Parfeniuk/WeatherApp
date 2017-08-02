import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { ForecastService } from '../services/forecast.service';

import { CurrentWeather} from '../models/current-weather';

@Component({
	selector: 'app-current-weather',
	templateUrl: './current-weather.component.html',
	styleUrls: ['./current-weather.component.css']
})
export class CurrentWeatherComponent implements OnInit {

	constructor(
		private forecastService: ForecastService,
		private route: ActivatedRoute
	) { }

	currentWeather: CurrentWeather;

	ngOnInit() {
		this.route.params
			.switchMap((params: Params) => this.forecastService.getCurrentWeatherInCity(params['city']))
			.subscribe(weather => this.currentWeather = weather);
	}
}
