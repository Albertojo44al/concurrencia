import { Component, OnInit } from '@angular/core';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {

  Evento:any ={
    name:"",
    price:0,
    artist:"",
    date:null
  }
  id:any;
  constructor(private _eventService: EventsService) { }

  ngOnInit(): void {
   
    this.id =   sessionStorage.getItem("eventId")
   this._eventService.getEvento(this.id)
   .subscribe(data => {
     this.Evento = data
     console.log(this.Evento);
   });
   console.log(this.Evento);
   
  }

  getEvent(){
    this.id =   sessionStorage.getItem("eventId")
   this._eventService.getEvento(this.id)
   .subscribe(data => {
     this.Evento = data
     console.log(this.Evento);
     
   });
  }

}
