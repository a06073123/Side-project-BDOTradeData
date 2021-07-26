import { Component, Input, AfterViewInit, ViewChild } from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexStroke,
  ApexNoData
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  noData: ApexNoData;
  xAxis: ApexXAxis;
  stroke: ApexStroke;
};

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})

export class ChartsComponent implements AfterViewInit {

  @ViewChild("chartObj") chart!: ChartComponent;

  @Input() tradeTime!: string[];
  @Input() chartName!: string;
  @Input() tradeData!: number[];

  public chartOptions: ChartOptions = {
    chart: {
      height: 350,
      type: "line",
      toolbar: {
        show: false
      }
    },
    series: [],
    xAxis: {},
    dataLabels: {
      enabled: false
    },
    noData: {
      text: 'Loading...'
    },
    stroke: {
      width: 1.5
    }
  };

  constructor() {
  }

  ngAfterViewInit(): void {
    this.chart.series = [{
      name: this.chartName,
      data: this.tradeData
    }];
    this.chart.xaxis = {
      categories: this.tradeTime,
      tickAmount: 15
    };
  }
}
