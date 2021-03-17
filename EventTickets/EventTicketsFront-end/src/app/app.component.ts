import { Component, OnInit } from '@angular/core';
import { EventsService } from './services/events.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'EventTicketsFront-end';

Events:any = [];

constructor(
  private _eventService: EventsService
){}

ngOnInit(){
  this._eventService.getCategories()
  .subscribe(data => this.Events = data);
  console.log(this.Events);
  
}

}
