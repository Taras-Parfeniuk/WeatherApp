import { City } from '../models/city';
import { SingleForecast } from '../models/single-forecast';

export class CurrentWeather extends SingleForecast {
	City: City;
}
