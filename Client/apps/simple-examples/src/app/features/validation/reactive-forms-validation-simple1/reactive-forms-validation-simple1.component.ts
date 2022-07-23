import { Component, HostListener, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Person } from '../../../_models/person.model';
import { State } from '../../../_models/state.model';
import { PeopleService } from '../../../_services/people.service';

@Component({
  selector: 'app-reactive-forms-validation-simple1',
  templateUrl: './reactive-forms-validation-simple1.component.html',
  styleUrls: ['./reactive-forms-validation-simple1.component.scss'],
})
export class ReactiveFormsValidationSimple1Component implements OnInit {
  person: Person | null = null;
  stateList: State[] = [];
  editForm2!: FormGroup;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    //     if (this.editForm.dirty){
    //       $event.returnValue = true;
    //     }
  }

  constructor(
    private route: ActivatedRoute,
    private peopleService: PeopleService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.stateList = data['states'];
    });

    const id = +this.route.snapshot.params['id'];
    this.updatePerson(id);
  }

  initializeForm(person: Person) {
    this.editForm2 = new FormGroup({
      firstName: new FormControl(person.firstName, Validators.required),
      lastName: new FormControl(person.lastName, Validators.required),
      email: new FormControl(person.email, Validators.email),
      dateOfBirth: new FormControl(person.dateOfBirth),
      addressLine1: new FormControl(person.addressLine1),
      addressLine2: new FormControl(person.addressLine2),
      city: new FormControl(person.city),
      state: new FormControl(person.state),
      postalCode: new FormControl(person.postalCode),
    });

    console.log(this.editForm2.value);
  }

  updateMember() {
    //console.log(this.editForm)
  }

  createPerson() {
    this.person = new Person();
    this.initializeForm(this.person);

  }

  updatePerson(id: number) {
    if (id == undefined) id = 1;
    this.peopleService
      .getById(id)
      .pipe(take(1))
      .subscribe((person) => {
        this.person = person;
        this.initializeForm(this.person);
        //  if (this.editForm){
        //   this.editForm.reset(person);
        //  }
      });
  }
}
