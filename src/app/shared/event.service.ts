import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Event } from './event';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  formData: Event = new Event();
  events: Event[];
  constructor(private httpClient: HttpClient) { }
  //get events for binding
  bindEvent() {
    this.httpClient
      .get(environment.apiUrl + '/api/event/getevents')
      .toPromise()
      .then((response) => (this.events = response as Event[]));
    console.log(this.events);
  }
  //insert an event
  insertEvent(event: Event): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/event/addevent", event);

  }
  updateEvent(event: Event): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/event/updateevent", event);
  }
  //get particular event
  getEventById(eventId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + '/api/event/geteventbyid?id=' + eventId);
    
  }

  UpdateEventByActive(id:number): Observable<any> {
  return this.httpClient.get(environment.apiUrl + "/api/event/isactive/" +id);
 }

}
