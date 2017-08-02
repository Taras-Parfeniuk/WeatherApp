import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { DatePipe } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { HistoryService } from '../services/history.service';

import { HistoryEntry } from '../models/history-entry';

@Component({
	selector: 'app-history-entry',
	templateUrl: './history-entry.component.html',
	styleUrls: ['./history-entry.component.css'],
	providers: [HistoryService]
})
export class HistoryEntryComponent implements OnInit {

	entry: HistoryEntry;

	constructor(
		private historyService: HistoryService,
		private route: ActivatedRoute,
		private location: Location
	) { }

	ngOnInit() {
		this.route.params
			.switchMap((params: Params) => this.historyService.getEntryById(params['id']))
			.subscribe(entry => this.entry = entry);
	}
}
