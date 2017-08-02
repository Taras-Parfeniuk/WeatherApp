import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { SingleForecast } from '../models/single-forecast';
import { MultipleForecast } from '../models/multiple-forecst';
import { CurrentWeather } from '../models/current-weather';
import { SortedHourlyForecast } from '../models/sorted-hourly-forecast'

@Injectable()
export class ForecastService {

	private resourceUrl = 'http://localhost:53090/api/forecast';

	constructor(private http: Http) { }

	getCurrentWeatherInCity(city : string): Promise<CurrentWeather> {
		var uri = `${this.resourceUrl}/current?city=${city}`;

		return this.http.get(uri).toPromise()
			.then(response => response.json() as CurrentWeather)
			.catch(this.handleError);
	}

	getHourlyForecastInCity(city: string): Promise<MultipleForecast> {
		var uri = `${this.resourceUrl}/hourly?city=${city}`

		return this.http.get(uri).toPromise()
			.then(response => response.json() as MultipleForecast)
			.catch(this.handleError);
	}

	getSortedHourlyForecastInCity(city: string): Promise<SortedHourlyForecast> {
		var uri = `${this.resourceUrl}/hourly?city=${city}&sorted=true`

		return this.http.get(uri).toPromise()
			.then(response => response.json() as SortedHourlyForecast)
			.catch(this.handleError);
	}

	getDailyForecastInCity(city: string): Promise<MultipleForecast> {
		var days = 16;
		var uri = `${this.resourceUrl}/daily?city=${city}&days=${days}`;

		return this.http.get(uri).toPromise()
			.then(response => response.json() as MultipleForecast)
			.catch(this.handleError);
	}

	private handleError(error: any): Promise<any> {
		console.error('An error occured', error);
		return Promise.reject(error.message || error);
	}
}
