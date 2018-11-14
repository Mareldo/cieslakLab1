import { Injectable } from '@angular/core';
import { extend } from 'webdriver-js-extender';
import { StudentsService } from './students.service';
import { Student } from '../model/student';

@Injectable()
export class StudentsLsService extends StudentsService {

  constructor() {
    super();
    this.LoadData();
  }

  public insert(student: Student) {
    super.insert(student);
    this.SaveStudent(student);
  }

  public update(student: Student) {
    super.update(student);
    this.SaveStudent(student);
  }

  private LoadData() {
    let ls = window.localStorage;
    for (let i = 0; i < ls.length; i++) {
      let key = ls.key(i);
      let stud = JSON.parse(ls.getItem(key));
      this.collection.push(stud);
    }
  }

  private SaveStudent(student: Student) {
    let ls = window.localStorage;
    ls.setItem(student.Id.toString(), JSON.stringify(student));
  }
}
