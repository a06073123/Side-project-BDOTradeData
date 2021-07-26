import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TradeService {

  apiUrl: string = "https://www.onzero.dev:9001";
  constructor(private http: HttpClient) { }

  getTradeItems(value: string): Observable<TradeItem[]> {
    return this.http.post<TradeItem[]>(`${this.apiUrl}/TradeItem/Search`, { "Name": `${value}` });
  }

  getTradeRecord(id: number): Observable<TradeShowRecord> {
    return this.http.get<TradeShowRecord>(`${this.apiUrl}/TradeRecord/${id}`);
  }

  getDailyRecord(): Observable<DailyShowRecord> {
    return this.http.get<DailyShowRecord>(`${this.apiUrl}/TradeRecord`);
  }
}
export interface TradeItem {
  mainKey: number;
  name: string;
  grade: number;
}

export interface TradeShowRecord {
  times: string[];
  mainKey: number;
  sumCounts: number[];
  totalSumCounts: number[];
  minPrices: number[];
}

export interface DailyShowRecord {
  times: string;
  names: string[];
  mainKeys: number[];
  tradingVolumes: number[];
}

interface customError {
  errorMessage: string;
}