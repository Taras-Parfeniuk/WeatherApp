import { Component, OnInit } from '@angular/core';

import { CitiesService } from '../services/cities.service';

import { City } from '../models/city';

@Component({
	selector: 'app-selected-cities',
	templateUrl: './selected-cities.component.html',
	styleUrls: ['./selected-cities.component.css']
})
export class SelectedCitiesComponent implements OnInit {

	constructor(private citiesService: CitiesService) { }

	selectedCities: City[];

	ngOnInit() {
		this.loadSelectedCities();
	}

	loadSelectedCities(): void {
		this.citiesService.getSelectedCities()
			.then(cities => this.selectedCities = cities);
	}

	removeFromSelected(id: number): void {
		this.citiesService.deleteFromSelected(id)
			.then(() => this.selectedCities = this.selectedCities.filter(c => c.Id !== id));
	}

	addToSelected(name: string): void {
		this.citiesService.getByName(name)
			.then(city => this.citiesService.addToSelected(city)
				.then(newCity => this.selectedCities.push(newCity)));
	}
}
