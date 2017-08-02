import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { SingleForecast } from '../models/single-forecast';
import { HistoryEntry } from '../models/history-entry';

@Injectable()
export class HistoryService {

	constructor(private http: Http) { }

	private resourceUrl = 'http://localhost:53090/api/history';

	getHistory(): Promise<HistoryEntry[]> {
		return this.http.get(this.resourceUrl).toPromise()
			.then(response => response.json() as HistoryEntry[])
			.catch(this.handleError);
	}

	getHistoryByCity(city: string): Promise<HistoryEntry[]> {
		var uri = `${this.resourceUrl}?cityName=${city}`

		return this.http.get(uri).toPromise()
			.then(response => response.json() as HistoryEntry[])
			.catch(this.handleError);
	}

	getEntryById(id: string): Promise<HistoryEntry> {
		var uri = `${this.resourceUrl}/${id}` 

		return this.http.get(uri).toPromise()
			.then(response => response.json() as HistoryEntry)
			.catch(this.handleError);
	}

	private handleError(error: any): Promise<any> {
		console.error('An error occured', error);
		return Promise.reject(error.message || error);
	}
}

