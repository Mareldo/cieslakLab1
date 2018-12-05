import { Component, OnInit } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from '../data-services/students-http.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: Student[];
  showForm: Boolean;

  sum: number;
  constructor(private ds: StudentsService) {
  }
  
  ngOnInit() {
    this.ds.getAll().subscribe((students) => {
      this.students = students;
      this.compute();
    });
    this.ds.onResult.subscribe(student => {
      this.students.push(student);
      this.compute();
    })
  }

  compute() {
    this.sum = this.students.reduce((a, cs) => a + parseFloat(cs.Grant.toString()), 0);
  }

  delete(student) {
    //this.ds.delete(student);
    this.compute();
  }
}
