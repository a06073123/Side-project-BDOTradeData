import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TradeItem, TradeService, TradeShowRecord } from '../trade.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  gradeColor: string[] = ["black", "green", "blue", "orange", "red"];
  tradeShowRecords!: TradeShowRecord;
  gotdata: boolean = false;
  tradeVolumeReocrds: number[] = [];
  activeIndex = 0;

  @Input() ti!: TradeItem;

  getImgUrl(): string {
    return `https://s1.pearlcdn.com/TW/TradeMarket/Common/img/BDO/item/${this.ti.mainKey}.png`;
  }

  constructor(private tds: TradeService, public route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.tds.getTradeRecord(this.ti.mainKey).subscribe(
      tsr => this.tradeShowRecords = tsr,
      () => { },
      () => {
        this.gotdata = true;
        let array = this.tradeShowRecords.totalSumCounts;
        for (let i = 0; i < array.length - 1; i++) {
          this.tradeVolumeReocrds.push(array[i + 1] - array[i]);
        }
      }
    );
  }

}
