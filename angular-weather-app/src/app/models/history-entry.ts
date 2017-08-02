import { City } from '../models/city';
import { SingleForecast } from '../models/single-forecast';

export class HistoryEntry {
	Id: string;
	City : City;
	QueryTime : string;
	Forecasts : SingleForecast[];
}