import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { StudentsService } from '../data-services/students.service';
import { Student } from '../model/student';
import { Router } from '@angular/router';


@Component({
  selector: 'app-studentform',
  templateUrl: './studentform.component.html',
  styleUrls: ['./studentform.component.css']
})
export class StudentFormComponent implements OnInit {

  form: FormGroup;

  constructor(private ds: StudentsService, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      Id: this.fb.control(0),
      FirstName: this.fb.control("", Validators.required),
      LastName: this.fb.control("", Validators.required),
      Grant: this.fb.control(0, Validators.required)
    });
  }

  save() {
    if (this.form.value.Id == 0)
      this.ds.insert(<Student>this.form.value);
    else
      this.ds.update(<Student>this.form.value);
    this.router.navigate(['/students']);
  }

  cancel() {
    this.router.navigate(['/students']);
  }
}
