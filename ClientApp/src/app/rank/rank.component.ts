import { Component, OnInit } from '@angular/core';
import { DailyShowRecord, TradeService } from '../trade.service';

@Component({
  selector: 'app-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.css']
})
export class RankComponent implements OnInit {
  dailyShowRecord!: DailyShowRecord;

  getImgUrl(mainKey: number): string {
    return `https://s1.pearlcdn.com/TW/TradeMarket/Common/img/BDO/item/${mainKey}.png`;
  }

  constructor(private tds: TradeService) { }

  ngOnInit(): void {
    this.getDailyShowRecord();
  }

  getDailyShowRecord(): void {
    this.tds.getDailyRecord().subscribe(
      dsr => this.dailyShowRecord = dsr
    );
  }

}
