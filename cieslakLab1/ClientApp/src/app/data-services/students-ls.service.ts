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
    this.SaveNextId();
  }

  public update(student: Student) {
    super.update(student);
    this.SaveStudent(student);
  }

  public delete(student: Student) {
    super.delete(student);
    this.RemoveStudent(student);
  }

  private LoadData() {
    let ls = window.localStorage;
    for (let i = 0; i < ls.length; i++) {
      let key = ls.key(i);
      if (key != "nextId") {
        let stud = JSON.parse(ls.getItem(key));
        this.collection.push(stud);
      }
    }
    this.nextId = parseInt(ls.getItem("nextId"));
    if (isNaN(this.nextId))
      this.nextId = 1;
  }

  private SaveStudent(student: Student) {
    let ls = window.localStorage;
    ls.setItem(student.Id.toString(), JSON.stringify(student));
  }

  private SaveNextId() {
    let ls = window.localStorage;
    ls.setItem("nextId", this.nextId.toString());
  }

  private RemoveStudent(student: Student) {
    let ls = window.localStorage;
    ls.removeItem(student.Id.toString());
  }
}
