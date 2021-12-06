import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Event } from 'src/app/shared/event';
import { EventService } from 'src/app/shared/event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  EventId: number;
  event: Event = new Event();
  Id: number;

  constructor(
    public eventService: EventService,
    private router: Router,
    private route: ActivatedRoute,
    private toasterService: ToastrService) { }

  ngOnInit(): void {
   
    this.Id = this.route.snapshot.params['eveId'];
      
      this.eventService.getEventById(this.Id).subscribe(
        data => {
          console.log(data);
          var datePipe = new DatePipe("en-UK");
        let formatedDate: any = datePipe.transform(data.EventDate,'yyyy-MM-dd');
        data.EventDate = formatedDate;
          this.eventService.formData = data;
        }
      );

    }

  onSubmit(form?: NgForm) {
    console.log(form.value);
    let Id = this.eventService.formData.EventId;

    if (Id == 0 || Id == null) {
      console.log("inserting record...");
      this.insertEvent(form);
    }
    else {
      console.log("updating record..");
      this.updateEvent(form);
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  insertEvent(form: NgForm) {
    //console.log(form.value);
    this.eventService.insertEvent(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success("Doctor Details Updated");
      }
    )
    window.location.reload();
  }

  updateEvent(form: NgForm) {
    
    this.eventService.updateEvent(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    )
    window.location.reload();
  }
  

}
