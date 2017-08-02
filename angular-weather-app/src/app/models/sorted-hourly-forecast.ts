import { City } from '../models/city';
import { SingleForecast } from '../models/single-forecast';

export class DayForecast {
	Date : string;
	Forecast : SingleForecast[];
}

export class SortedHourlyForecast {
	City : City;
	DayForecasts : DayForecast[]; 
}
	