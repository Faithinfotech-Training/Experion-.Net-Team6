import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventService } from 'src/app/shared/event.service';
import { Event } from 'src/app/shared/event';

@Component({
  selector: 'app-eventlist',
  templateUrl: './eventlist.component.html',
  styleUrls: ['./eventlist.component.css']
})
export class EventlistComponent implements OnInit {
  page:number =1;
  PatientId: number;
  Id:number;
  filter : string;
  route: any;

  constructor(public eventService:EventService,private router:Router) { }
  ngOnInit(): void {
   
    this.eventService.bindEvent();
    }
    populateForm(eve:Event){
      console.log(eve);
      //date format
      var datePipe = new DatePipe("en-UK");
      let formatedDate:any = datePipe.transform(eve.EventDate,'yyyy-MM-dd');
      eve.EventDate = formatedDate;
      this.eventService.formData =Object.assign({},eve); 
    }
  
 //update an event through routing
onclick(eventId: number){
 console.log(eventId);
 this.router.navigate(['addevent', eventId]);
 
} 
updateStatus(EventId: number){

    this.eventService.UpdateEventByActive(EventId).subscribe(

      (result)=>{

        console.log(result);

      }

    )
   window.location.reload();
  }
  
 
}