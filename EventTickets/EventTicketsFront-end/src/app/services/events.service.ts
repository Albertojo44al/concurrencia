import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EventsService {

  private url = "https://localhost:44364/api/EventTickets/categories";
  constructor(
    private http: HttpClient        
  ) { }

  getCategories() {
    return this.http.get<any[]>(this.url);
  } 



}
