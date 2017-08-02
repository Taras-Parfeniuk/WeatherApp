import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DatePipe } from '@angular/common';

import { HistoryService } from '../services/history.service';

import { HistoryEntry } from '../models/history-entry';

@Component({
	selector: 'app-history',
	templateUrl: './history.component.html',
	styleUrls: ['./history.component.css'],
	providers: [HistoryService]
})
export class HistoryComponent implements OnInit {

	constructor(
		private historyService: HistoryService,
		private router: Router
	) { }

	history: HistoryEntry[];

	ngOnInit() {
		this.loadHistory();
	}

	goToEntry(id: string): void {
		this.router.navigate(['/history', id]);
	}

	loadHistory(): void {
		this.historyService.getHistory()
			.then(entries => this.history = entries);
	}

	loadHistoryByCity(city: string): void {
		this.history = [];
		this.historyService.getHistoryByCity(city)
			.then(entries => this.history = entries);
	}
}
