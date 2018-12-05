import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { StudentsService } from '../data-services/students-http.service';
import { Student } from '../model/student';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-studentform',
  templateUrl: './studentform.component.html',
  styleUrls: ['./studentform.component.css']
})
export class StudentFormComponent implements OnInit {

  form: FormGroup;

  constructor(private ds: StudentsService,
              private fb: FormBuilder,
              private router: Router,
              private ar: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      Id: this.fb.control(0),
      FirstName: this.fb.control("", Validators.required),
      LastName: this.fb.control("", Validators.required),
      Grant: this.fb.control(0, Validators.required)
    });

    this.ar.params.subscribe((param) => {

      let id = param['id'];
      if (id) {
        let student = this.ds.findbyId(id);
        this.form.setValue(Object.assign(new Student(), student));
      } else {
        this.form.setValue(new Student());
      }
    });
  }

  save() {
    if (this.form.value.Id == 0)
      this.ds.insert(<Student>this.form.value)
        .subscribe((stud) => this.router.navigate(['/students']));
    else
      this.ds.update(<Student>this.form.value);
    
  }

  cancel() {
    this.router.navigate(['/students']);
  }
}
