import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Person } from '../../../_models/person.model';
import { State } from '../../../_models/state.model';
import { PeopleService } from '../../../_services/people.service';

@Component({
  selector: 'app-forms-validation-simple1',
  templateUrl: './template-forms-validation-simple1.component.html',
  styleUrls: ['./template-forms-validation-simple1.component.scss']
})
export class TemplateFormsValidationSimple1Component implements OnInit {
  person: Person | null = null;
  stateList: State[] = [];
  @ViewChild('editForm') editForm!: NgForm;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty){
      $event.returnValue = true;
    }
 }

  constructor(private route: ActivatedRoute,
    private peopleService: PeopleService) { }

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.stateList = data['states'];
    });

    const id = +this.route.snapshot.params['id'];
    this.updatePerson(id);
  }


  updateMember() {
    console.log(this.editForm)
  }

  createPerson() {
    this.person = new Person();
  }

  updatePerson(id: number) {
     if (id == undefined) id = 1;
     this.peopleService.getById(id).pipe(take(1)).subscribe(person => {
     // if (person.dateOfBirth) {
      ///  const dateAsString = new Date().toISOString().split('T')[0];
       // person.dateOfBirth = new Date(dateAsString);
//console.log(dateAsString);
    //  }
       this.person = person;
       if (this.editForm){
        this.editForm.reset(person);
       }
      });
  }
}
