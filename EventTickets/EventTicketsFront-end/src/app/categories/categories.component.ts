
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

 
  Events:any = [];
  constructor(
    private _eventService: EventsService,
    private _router: Router
    ) { }

  ngOnInit(): void {
    this._eventService.getCategories()
    .subscribe(data => {
      this.Events = data;
      console.log(this.Events);
    });
    
  }

  navigateEvent(id){
    console.log('aver');
    
    sessionStorage.setItem('eventId',id);
    this._router.navigate(["/evento"]);
  }

}
