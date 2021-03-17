import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EventsService {

  private url = "https://localhost:44364/api/EventTickets";
  constructor(
    private http: HttpClient        
  ) { }

  getCategories() {
    return this.http.get<any[]>(`${this.url}/categories`);
  } 

  getEvento(id){
   
    return this.http.get<any[]>(`${this.url}/events?categoryid=${id}`);
  }



}
