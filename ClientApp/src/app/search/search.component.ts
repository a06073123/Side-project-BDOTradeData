import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError } from 'rxjs/operators';

import { TradeService, TradeItem } from '../trade.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  tradeItems: TradeItem[] = [];
  pageSize = 5;
  page = 1;

  constructor(private tds: TradeService, private route: ActivatedRoute) {

  }

  search(value: string): void {
    this.tds.getTradeItems(value).subscribe(tradeItems => this.tradeItems = tradeItems);
  }

  ngOnInit(): void {
  }
}
