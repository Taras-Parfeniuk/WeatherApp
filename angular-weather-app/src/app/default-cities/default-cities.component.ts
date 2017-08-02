import { Component, OnInit } from '@angular/core';

import { CitiesService } from '../services/cities.service';

import { City } from '../models/city';

@Component({
	selector: 'app-default-cities',
	templateUrl: './default-cities.component.html',
	styleUrls: ['./default-cities.component.css'],
	providers: [CitiesService]
})
export class DefaultCitiesComponent implements OnInit {
	defaultCities: City[];
	title: string;

	constructor(private citiesService: CitiesService) {	 }

	ngOnInit() {
		this.loadDefaultCities();
	}

	loadDefaultCities() : void {
		this.citiesService.getDefaultCities()
			.then(cities => this.defaultCities = cities);
	}
}
