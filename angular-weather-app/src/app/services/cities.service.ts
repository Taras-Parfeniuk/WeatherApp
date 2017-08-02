import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { City } from '../models/city';

@Injectable()
export class CitiesService {

	private headers: Headers = new Headers();
	private resourceUrl = 'http://localhost:53090/api/cities';

	constructor(private http: Http) { }

	getDefaultCities(): Promise<City[]> {
		var uri = `${this.resourceUrl}/default`;

		return this.http.get(uri).toPromise()
			.then(response => response.json() as City[])
			.catch(this.handleError);
	}

	getSelectedCities(): Promise<City[]> {
		return this.http.get(this.resourceUrl).toPromise()
			.then(response => response.json() as City[])
			.catch(this.handleError);
	}

	addToSelected(city: City): Promise<City> {
		return this.http.post(this.resourceUrl, JSON.stringify(city), { headers: this.headers }).toPromise()
			.then(response => response.json() as City)
			.catch(this.handleError);
	}

	getByName(name: string): Promise<City> {
		var uri = `${this.resourceUrl}?cityName=${name}`;

		return this.http.get(uri).toPromise()
			.then(response => response.json() as City)
			.catch(this.handleError);
	}

	deleteFromSelected(id: number): Promise<void> {
		var uri = `${this.resourceUrl}/${id}`;
		return this.http.delete(uri, { headers: this.headers }).toPromise()
			.then(() => null)
			.catch(this.handleError);
	}

	private handleError(error: any): Promise<any> {
		console.error('An error occured', error);
		return Promise.reject(error.message || error);
	}
}
